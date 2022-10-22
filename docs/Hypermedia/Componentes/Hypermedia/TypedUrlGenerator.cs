using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia {
    public class TypedUrlGenerator {
        private static readonly ConcurrentDictionary<string, string> ControllerActionRouteNames = new ConcurrentDictionary<string, string>();

        public TypedUrlGenerator(UrlHelper urlHelper, string scheme, string hostName, string defaultControllerName) {
            if (urlHelper == null) {
                throw new ArgumentNullException(nameof(urlHelper));
            }

            DefaultControllerName = defaultControllerName;
            Scheme = scheme;
            HostName = hostName;
            Url = urlHelper;
        }

        private string DefaultControllerName { get; }
        private string Scheme { get; }
        public string HostName { get; set; }
        public static TypedUrlGenerator Current => HttpContext.Current.Items["UrlGenerator"] as TypedUrlGenerator;
        private UrlHelper Url { get; }

        public static Func<TypedUrlGenerator> Factory { get; set; }

        public Uri Generate(string namedRoute, RouteValueDictionary values) {
            return new Uri(Url.RouteUrl(namedRoute, values, Scheme, HostName));
        }

        public Uri Generate(Expression<Action> controllerAction, object routeValues = null) {
            return Generate(DefaultControllerName, controllerAction, routeValues);
        }

        public Uri Generate(Expression<Func<Task>> controllerAction, object routeValues = null) {
            return Generate(DefaultControllerName, controllerAction, routeValues);
        }

        public Uri Generate<TController>(Expression<Action<TController>> controllerAction, object routeValues = null) {
            return Generate(GetControllerName(typeof(TController)), controllerAction, routeValues);
        }

        public Uri Generate<TController>(Expression<Func<TController, Task>> controllerAction, object routeValues = null) {
            return Generate(GetControllerName(typeof(TController)), controllerAction, routeValues);
        }

        private static IDictionary<string, object> ObjectToDictionary(object o) {
            return o?.GetType()
                .GetProperties()
                .ToDictionary(
                    prop => prop.Name,
                    prop => prop.GetValue(o, null));
        }

        private Uri Generate<T>(string controller, Expression<T> controllerAction, object routeValues = null) {
            var additionalRouteValues = ObjectToDictionary(routeValues);
            var methodCallExpression = (MethodCallExpression)controllerAction.Body;

            var values = methodCallExpression.Method
                .GetParameters()
                .SelectMany(p => ValuateExpression(methodCallExpression, p))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            additionalRouteValues?.ToList().ForEach(kvp => values.Add(kvp.Key, kvp.Value));

            return ResolveUrl(controller, methodCallExpression, values);
        }

        private Uri ResolveUrl(string controller, MethodCallExpression expression, IDictionary<string, object> values) {
            var routeValues = new RouteValueDictionary(values.
                Select(AdjustToIsoDate)
                .ToDictionary(x => x.Key, y => y.Value));
            string routeName;
            var url = TryGetRouteName(controller, expression, out  routeName) ?
                Url.RouteUrl(routeName, routeValues, Scheme, HostName) :
                Url.Action(expression.Method.Name, controller, routeValues, Scheme);

            if (string.IsNullOrEmpty(url)) {
                throw new ArgumentException($"Route could not be found. Controller: {controller}, Action: {expression.Method.Name}");
            }

            return new Uri(url);
        }

        private KeyValuePair<string, object> AdjustToIsoDate(KeyValuePair<string, object> keyValuePair) {
            if (keyValuePair.Value is DateTimeOffset )
            {
                var date = keyValuePair.Value as DateTimeOffset?;
                return new KeyValuePair<string, object>(keyValuePair.Key, date.Value.ToString("o"));
            }
            return keyValuePair;
        }

        private static bool TryGetRouteName(string controller, MethodCallExpression expression, out string routeName) {
            var routeKey = $"{controller}.{expression.Method.Name}";
            if (ControllerActionRouteNames.TryGetValue(routeKey, out routeName)) {
                return !string.IsNullOrEmpty(routeName);
            }

            var routeAttribute = expression.Method
                .GetCustomAttributes(true)
                .OfType<RouteAttribute>()
                .FirstOrDefault();

            ControllerActionRouteNames.AddOrUpdate(routeKey, routeAttribute?.Name, (key, oldValue) => oldValue);

            if (string.IsNullOrEmpty(routeAttribute?.Name)) {
                return false;
            }

            routeName = routeAttribute.Name;
            return true;
        }

        private static string GetControllerName(Type controllerType) {
            return controllerType.Name.Replace("Controller", string.Empty);
        }

        private static IReadOnlyCollection<KeyValuePair<string, object>> SingleValue(string key, object v)
        {
            return new[] { new KeyValuePair<string, object>(key, v) };
        }

        private static IReadOnlyCollection<KeyValuePair<string, object>> ValuateExpression(MethodCallExpression methodCallExpression, ParameterInfo parameter) {
            var argument = methodCallExpression.Arguments[parameter.Position];
            var constantExpression = argument as ConstantExpression;

            if (constantExpression != null) {
                return SingleValue(parameter.Name, constantExpression.Value);
            }

            var lambdaExpression = Expression.Lambda(argument, Enumerable.Empty<ParameterExpression>());
            var value = lambdaExpression.Compile().DynamicInvoke();

            if (value != null && value.GetType().BaseType == typeof(Enum)) {
                return SingleValue(parameter.Name, (int)value);
            }

            if (value != null && value is IList)
            {
                var list = value as IList;
                return list.ToPropertiesDictionary(parameter.Name);
            }

            return SingleValue(parameter.Name, value);
        }
    }
}