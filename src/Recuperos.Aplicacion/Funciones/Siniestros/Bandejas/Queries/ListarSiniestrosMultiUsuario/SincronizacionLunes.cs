using System;
using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
   public class SincronizacionLunes
    {
        public bool InicializarSincros { get; set; }
        public bool HayPendientes { get; set; }
        public List<DateTime> PendientesSincronizacion { get; set; }
    }
}
