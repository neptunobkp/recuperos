using System.Collections.Generic;

namespace Recuperos.Aplicacion.Interfaces.Models
{
    public class ExcelDespacho
    {
        public ExcelDespacho()
        {
            Filas = new List<ExcelFilaDespacho>();
            Columnas = new List<string>();
        }

        public List<string> Columnas { get; set; }
        public List<ExcelFilaDespacho> Filas { get; set; }
    }
}
