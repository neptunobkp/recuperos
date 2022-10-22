using System;
using System.Linq;
using System.Linq.Expressions;

namespace Recuperos.Aplicacion.Comun.Helpers
{
 
    public static class OrdenamientoHelperExtension
    {
        public static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string propertyName, string direccionOrden, bool anotherLevel = false)
        {
            propertyName = propertyName.Replace("_", ".");
            var sortResult = propertyName.Contains(".") ? CreateNestedExpression(typeof(T), propertyName) : CreateSimpleExpression(typeof(T), propertyName);

            var call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") +
                (direccionOrden == "desc" ? "Descending" : string.Empty),
                new[] { typeof(T), sortResult.MemberAccess.Type },
                source.Expression,
                Expression.Quote(sortResult.Lambda));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
        private sealed class HoldPropertyValue<T>
        {
            public T v;
        }
        public static IQueryable<T> WhereEquals<T>(this IQueryable<T> query, string propertyName, object propertyValue)
        {
            var pe = Expression.Parameter(typeof(T), "p");
            var property = Expression.PropertyOrField(pe, propertyName);
            var holdpv = new HoldPropertyValue<object> { v = propertyValue };
            var value = Expression.Convert(Expression.PropertyOrField(Expression.Constant(holdpv), "v"), property.Type);
            var predicateBody = Expression.Equal(
                property,
                value
            );
            var wf = Expression.Lambda<Func<T, bool>>(predicateBody, new ParameterExpression[] { pe });
            var whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { typeof(T) },
                query.Expression,
                wf
            );
            return query.Provider.CreateQuery<T>(whereCallExpression);
        }

        private static PropertyOrMemeberExpression CreateSimpleExpression(Type type, string propertyName)
        {
            var resultado = new PropertyOrMemeberExpression();
            var param = Expression.Parameter(type, string.Empty);
            resultado.MemberAccess = Expression.PropertyOrField(param, propertyName);
            resultado.Lambda = Expression.Lambda(resultado.MemberAccess, param);
            return resultado;
        }

        private static PropertyOrMemeberExpression CreateNestedExpression(Type type, string propertyName)
        {
            var resultado = new PropertyOrMemeberExpression();
            var param = Expression.Parameter(type, "x");
            Expression body = param;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }

            resultado.Lambda = Expression.Lambda(body, param);
            resultado.MemberAccess = body as MemberExpression;
            return resultado;
        }
    }
}
