using System.Linq.Expressions;

namespace Recuperos.Aplicacion.Comun.Helpers
{
    public class PropertyOrMemeberExpression
    {
        public LambdaExpression Lambda { get; set; }
        public MemberExpression MemberAccess { get; set; }
    }
}