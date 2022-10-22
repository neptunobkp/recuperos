using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperios.Servicios.Recup02.Mocks
{
    public class ApiRecup02Mock : IApiRecup02
    {
        public Task<List<Siniestro>> GetSiniestros(DateTime fecha)
        {
            var siniestros = MockearSiniestros();
            return Task.FromResult(siniestros);
        }

        public Task<HttpResponseMessage> GetAccidente(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    CALLEACCIDENTE = "OHIGGINS                      ",
                    COMUNA = "ANG",
                    CIUDAD = "ANG",
                    ACOHOLEMIAACCIDENTE = "S"
                })
            };
            return Task.FromResult(response);
        }



        public Task<HttpResponseMessage> GetConstancia(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    PREFECTURACONSTANCIA = "PRIMERA COMISARI ANGOL        ",
                    NPARTECONSTANCIA = 864,
                    CITACIONJURADA = "S",
                    FECHACITACIONCONSTANCIADIA = 22,
                    FECHACITACIONCONSTANCIAMES = 6,
                    FECHACITACIONCONSTANCIAANIO = 2017
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetDenunciante(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    NOMBRE = "Natalia Arriola Aguilera      ",
                    DIRECCION = "Antonio Bellet 292            ",
                    CCIUDAD = "PRO",
                    RUT = 16810819,
                    TELEFONO1 = "0022751910",
                    TELEFONO2 = "0000000000"
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetAsegurado(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    RUT = 4015630,
                    DV = "5",
                    NOMBRES = "LUIS OSVALDO TOBIAS DEL RIO PEREIRA     ",
                    CORREO = "notiene@gmail.com",
                    TELEFONOCOMERCIAL = 0,
                    TELEFONOPOSTAL = 2422824
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetLiquidador(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    RUT = 12378851,
                    DV = "6",
                    NOMBRES = "REYES ARENAS DANIEL ANTONIO             ",
                    CORREO = "daniel.reyes@bciseguros.cl                                                                          ",
                    TELEFONOCOMERCIAL = 931947345,
                    TELEFONOPOSTAL = 931947345
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetConductor(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    RUT = 4224237,
                    DV = "3",
                    NOMBRES = "MOCKED DEL CARMEN MENA LEON             ",
                    FONO = "227519100                     ",
                    DIRECCION = "AVENIDA SANTA MARIA 6560 DEPTO C 406                        ",
                    CORREO = "EJECUTIVO2.SINIESTROS@AGESE.CL                              "
                })
            };
            return Task.FromResult(response);
        }



        public Task<HttpResponseMessage> GetVehiculo(string tipoDocumento, string codigoSucursal, int numeroDocumento, int itemDocumento)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    TIPOVEHICULO = "09",
                    MARCA = "JEE",
                    MODELO = "02",
                    VERSION = "04",
                    ANIOFABRICACION = 2014,
                    NUMEROMOTOR = "EC230326            ",
                    PATENTE = "GLGT34",
                    COLOR = "NEGRO     ",
                    NUMEROCHASIS = "1C4RJFBM9EC230326   "
                })
            };
            return Task.FromResult(response);
        }
        public Task<HttpResponseMessage> GetRelato(int numero)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new object[]
                {
                    new { Linea=0, Texto ="VLC" },
                    new { Linea=1, Texto ="SINIESTRO DENUNCIADO VIA WEB POR UN USUARIO EXTERNO                             " },
                })
            };
            return Task.FromResult(response);
        }



        private static List<Siniestro> MockearSiniestros()
        {
            #region siniestros
            var siniestros = new List<Siniestro>()
            {
                new Siniestro { Id = 6595333, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9731422, NumeroItem = 1},
                new Siniestro { Id = 6630355, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9891456, NumeroItem = 1},
                new Siniestro { Id = 6630945, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9663715, NumeroItem = 1},
                new Siniestro { Id = 6631403, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =8993668, NumeroItem = 1},
                new Siniestro { Id = 6631414, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =8943579, NumeroItem = 1},
                new Siniestro { Id = 6631448, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9732509, NumeroItem = 1},
                new Siniestro { Id = 6631480, TipoDocumento = "P", CodigoSucursal = "H", NumeroPoliza =1902, NumeroItem = 1},
                new Siniestro { Id = 6631495, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1424345, NumeroItem = 17},
                new Siniestro { Id = 6631498, TipoDocumento = "P", CodigoSucursal = "C", NumeroPoliza =653627, NumeroItem = 1},
                new Siniestro { Id = 6631505, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =4172972, NumeroItem = 1},
                new Siniestro { Id = 6631509, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =4299304, NumeroItem = 1},
                new Siniestro { Id = 6631524, TipoDocumento = "P", CodigoSucursal = "O", NumeroPoliza =53477, NumeroItem = 1},
                new Siniestro { Id = 6631529, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1427566, NumeroItem = 1},
                new Siniestro { Id = 6631540, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9635972, NumeroItem = 1},
                new Siniestro { Id = 6631554, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9889524, NumeroItem = 1},
                new Siniestro { Id = 6631567, TipoDocumento = "P", CodigoSucursal = "U", NumeroPoliza =124329, NumeroItem = 1},
                new Siniestro { Id = 6631587, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =1645175, NumeroItem = 1},
                new Siniestro { Id = 6631615, TipoDocumento = "P", CodigoSucursal = "V", NumeroPoliza =1038687, NumeroItem = 49},
                new Siniestro { Id = 6631618, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =4426560, NumeroItem = 1},
                new Siniestro { Id = 6631630, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =8944365, NumeroItem = 1},
                new Siniestro { Id = 6631639, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9685199, NumeroItem = 1},
                new Siniestro { Id = 6631645, TipoDocumento = "P", CodigoSucursal = "L", NumeroPoliza =65180, NumeroItem = 1},
                new Siniestro { Id = 6631652, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9769149, NumeroItem = 1},
                new Siniestro { Id = 6631676, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1419221, NumeroItem = 4},
                new Siniestro { Id = 6631697, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =5136976, NumeroItem = 1},
                new Siniestro { Id = 6631702, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9084209, NumeroItem = 1},
                new Siniestro { Id = 6631723, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9461219, NumeroItem = 1},
                new Siniestro { Id = 6631725, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9087262, NumeroItem = 1},
                new Siniestro { Id = 6631761, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1403466, NumeroItem = 2},
                new Siniestro { Id = 6631808, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9496303, NumeroItem = 1},
                new Siniestro { Id = 6631836, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =4875395, NumeroItem = 1},
                new Siniestro { Id = 6631851, TipoDocumento = "P", CodigoSucursal = "Q", NumeroPoliza =786897, NumeroItem = 1},
                new Siniestro { Id = 6631857, TipoDocumento = "P", CodigoSucursal = "G", NumeroPoliza =49408, NumeroItem = 1},
                new Siniestro { Id = 6631868, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9639319, NumeroItem = 1},
                new Siniestro { Id = 6631875, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9494289, NumeroItem = 1},
                new Siniestro { Id = 6631891, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =4301418, NumeroItem = 1},
                new Siniestro { Id = 6631903, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9773775, NumeroItem = 1},
                new Siniestro { Id = 6631908, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9878188, NumeroItem = 1},
                new Siniestro { Id = 6631914, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1448242, NumeroItem = 36},
                new Siniestro { Id = 6631921, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9219729, NumeroItem = 1},
                new Siniestro { Id = 6631925, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1432070, NumeroItem = 139},
                new Siniestro { Id = 6631927, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1443281, NumeroItem = 1},
                new Siniestro { Id = 6631930, TipoDocumento = "P", CodigoSucursal = "M", NumeroPoliza =1432070, NumeroItem = 73},
                new Siniestro { Id = 6631934, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9347601, NumeroItem = 1},
                new Siniestro { Id = 6631935, TipoDocumento = "P", CodigoSucursal = "U", NumeroPoliza =111931, NumeroItem = 1},
                new Siniestro { Id = 6631949, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9087749, NumeroItem = 1},
                new Siniestro { Id = 6631959, TipoDocumento = "P", CodigoSucursal = "B", NumeroPoliza =4945262, NumeroItem = 1},
            };
            #endregion

            foreach (var cadasSiniestro in siniestros)
            {
                cadasSiniestro.FechaDenuncio = new DateTime(2019, 3, 1);
                cadasSiniestro.FechaSiniestro = new DateTime(2019, 3, 1);
                cadasSiniestro.Compania = "Bci Seguros";
                cadasSiniestro.EstadoId = (int)TiposEstado.Analisis;
            }

            return siniestros;
        }
    }
}
