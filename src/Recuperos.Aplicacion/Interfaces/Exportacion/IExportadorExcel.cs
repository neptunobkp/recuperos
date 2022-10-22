using System.Collections.Generic;

namespace Recuperos.Aplicacion.Interfaces.Exportacion
{
    public interface IExportadorExcel
    {
        byte[] Exportar<T>(IList<T> data);
    }
}
