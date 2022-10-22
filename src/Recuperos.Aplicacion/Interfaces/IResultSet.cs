using System.Collections.Generic;

namespace Recuperos.Aplicacion.Interfaces
{
    public interface IResultSet<T>
    {
        ICollection<T> Lista { get; set; }
        int Total { get; set; }
    }
}
