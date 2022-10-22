using System;
using System.Linq;

namespace Recuperos.Aplicacion.Comun.Helpers
{
    public static class RutHelper
    {
        public static string DigitoVerificador(Int32 rut)
        {
            double T = rut;
            double M = 0, S = 1;
            while (T != 0)
            {
                S = (S + T % 10 * (9 - M++ % 6)) % 11;
                T = Math.Floor(T / 10);
            }
            string dv = S != 0 ? (S - 1).ToString() : "K";
            return dv;
        }
        public static string DigitoVerificador(string rut)
        {
            if (rut.EndsWith("k") || rut.EndsWith("K"))
                return "K";

            var rutLimpio = rut.Split('-').First().Replace(".", "");
            int rutValor = 0;
            if (int.TryParse(rutLimpio, out rutValor))
            {
                if (rutValor < 99999999)
                    return DigitoVerificador(rutValor);

                int rutValor2 = 0;
                if (int.TryParse(rutLimpio.Substring(0, rutLimpio.Length - 1), out rutValor2))
                    return DigitoVerificador(rutValor2);
            }

            return string.Empty;
        }

        public static bool EsRutConDv(string rut)
        {
            if (string.IsNullOrEmpty(rut))
                return false;

            if (!rut.Contains("-"))
                return false;

            rut = rut.Trim();

            var partesRut = rut.Split('-');
            if (partesRut.Length != 2)
                return false;

            int n;
            bool esNumerico = int.TryParse(partesRut.FirstOrDefault().Replace(".", ""), out n);

            if (!esNumerico)
                return false;

            if (partesRut.Last().Length != 1)
                return false;

            return true;
        }

        public static int? ExtraerRutDeFormateado(string rut)
        {
            if (EsRutConDv(rut))
            {
                var partesRut = rut.Split('-');
                int n;
                if (int.TryParse(partesRut.FirstOrDefault().Replace(".", ""), out n))
                    return n;
            }
            return null;
        }


      

        public static string Rut(int rut)
        {
            return $"{Formatear(rut.ToString())}-{DigitoVerificador(rut)}";
        }

        public static bool RutFormateadoEsValido(string rut)
        {
            rut = rut?.ToUpper();
            return string.IsNullOrEmpty(rut) || rut.EndsWith(DigitoVerificador(ExtraerRutDeRutFormateado(rut).GetValueOrDefault()));
        }

        public static int? ExtraerRutDeRutFormateado(string rutFormateado)
        {
            if (string.IsNullOrEmpty(rutFormateado)) return null;

            rutFormateado = rutFormateado.ToUpper();
            rutFormateado = rutFormateado.Replace(",", "");
            rutFormateado = rutFormateado.Replace(".", "");

            if (rutFormateado.Contains("-"))
            {
                rutFormateado = rutFormateado.Replace("-", "");
                rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);
            }
            else
            {
                rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);
            }

            int resultado = 0;
            if (int.TryParse(rutFormateado, out resultado))
                return resultado;

            return null;
        }

        public static int ExtraerRutDeRutFormateadoSinDv(string rutFormateado)
        {
            if (string.IsNullOrEmpty(rutFormateado)) return 0;

            rutFormateado = rutFormateado.ToUpper();
            rutFormateado = rutFormateado.Replace(",", "");
            rutFormateado = rutFormateado.Replace(".", "");

            if (rutFormateado.Contains("-"))
            {
                rutFormateado = rutFormateado.Replace("-", "");
                rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);
            }

            int resultado = 0;
            if (int.TryParse(rutFormateado, out resultado))
                return resultado;

            return 0;
        }

        public static string Formatear(string rut)
        {
            int cont = 0;
            var format = string.Empty;
            if (rut.Length != 0)
            {
                for (int i = rut.Length - 1; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
            }
            return format;
        }

    }
}
