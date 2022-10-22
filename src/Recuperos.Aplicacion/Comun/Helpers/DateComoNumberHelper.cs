using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario;
using DateTime = System.DateTime;

namespace Recuperos.Aplicacion.Comun.Helpers
{
    public static class DateComoNumberHelper
    {
        public static int Hoy()
        {
            return Calcular(DateTime.Now);
        }

        public static int Ayer()
        {
            return Calcular(DateTime.Now.AddDays(-1));
        }

        public static int Calcular(DateTime fecha)
        {
            return Convert.ToInt32(
                $"{fecha.Year}{fecha.Month.ToString().PadLeft(2, '0')}{fecha.Day.ToString().PadLeft(2, '0')}");
        }

        public static DateTime Calcular(int valor)
        {
            return DateTime.ParseExact(valor.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        public static SincronizacionLunes EvaluarSiSincronizar(int ultimaSincro)
        {
            return new SincronizacionLunes
            {
                HayPendientes = ultimaSincro < Hoy(),
                PendientesSincronizacion = ObtenerFechasPendientes(ultimaSincro < Hoy(),ultimaSincro)
            };
        }

        private static List<DateTime> ObtenerFechasPendientes(bool hayPendientes, int ultimaSincro)
        {
            var resultado = new List<DateTime>();
            if (!hayPendientes)
                return resultado;
          
            for (DateTime i = Calcular(ultimaSincro).AddDays(1); i <= Calcular(Ayer()); i = i.AddDays(1))
                resultado.Add(i);

            return resultado;
        }

        public static List<DateTime> ListarRango(DateTime desde, DateTime hasta)
        {
            var resultado = new List<DateTime>();
            for (DateTime i = desde; i <= hasta; i = i.AddDays(1))
                resultado.Add(i);
            return resultado;
        }

        public static DateTime? Parsear(int? valor)
        {
            if (!valor.HasValue) return null;
            DateTime resultado;
            return DateTime.TryParseExact(valor.Value.ToString(), "yyyyMMdd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out resultado) ? resultado : (DateTime?)null;
        }

        public static DateTime? Parsear(string valor)
        {
            int convertido;
            return int.TryParse(valor, out convertido) ? Parsear(convertido) : (DateTime?) null;
        }
    }
}
