using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Servicios.Migracion.Commands.Migrar
{
    public class ResultadoMigracion
    {
        public ResultadoMigracion()
        {
            Fallos = new Dictionary<int, string>();
        }

        public int Total { get; set; }
        public int Cargados { get; set; }
        public int Fallidos { get; set; }
        public Dictionary<int, string> Fallos { get; set; }
    }
}