using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ControllerAuthorizationChecker {
        public static bool IsAuthorizedToExecute<T>(this Expression<T> controllerAction) {
            var claimsPrincipal = HttpContext.Current.User as ClaimsPrincipal;

            if (claimsPrincipal == null) {
                return false;
            }

            var userRoles = claimsPrincipal.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            var methodCallExpression = (MethodCallExpression)controllerAction.Body;
            var authorizeAttributes = methodCallExpression.Method
                .GetCustomAttributes(true)
                .Where(a => a.GetType() == typeof(AuthorizeAttribute))
                .Cast<AuthorizeAttribute>()
                .ToList();

            if (authorizeAttributes.Count > 0 && authorizeAttributes.All(a => a.Roles != null && a.Roles.Any())) {
                return authorizeAttributes.Any(a => (a.Roles.Split(',').Select(x => x.Trim()).Intersect(userRoles, StringComparer.OrdinalIgnoreCase)).Any());
            }

            return true;
        }
    }
}