using System.Collections.Generic;

namespace Recuperos.Aplicacion.Interfaces.Models
{
    public class ExcelFilaDespacho
    {
        public ExcelFilaDespacho()
        {
            Items = new Dictionary<int, string>();
        }
        public Dictionary<int, string> Items { get; set; }
    }
}
