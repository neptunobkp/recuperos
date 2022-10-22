using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Servicios.Recup02.Mocks
{
    public class ApiRecup02Mock : IApiRecup02
    {
        public Task<List<Siniestro>> GetSiniestros(DateTime fecha) => Task.FromResult(MockearSiniestros());
        public Task<List<Siniestro>> GetSiniestros(int numero, TiposCompania compania) => Task.FromResult(MockearSiniestros());
        public Task<List<Siniestro>> GetSeedSiniestros(DateTime fecha) => Task.FromResult(MockearSiniestros());

        public Task<HttpResponseMessage> GetAccidente(int numero, int compania)
        {
            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    CALLEACCIDENTE = "CALLE HUERFANOS",
                    COMUNA = "SANTIAGO",
                    CIUDAD = "SANTIAGO",
                    ACOHOLEMIAACCIDENTE = "S"
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetConstancia(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

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

        public Task<HttpResponseMessage> GetDenunciante(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    NOMBRE = "Natalia Arriola Aguilera      ",
                    DIRECCION = "Antonio Bellet 292            ",
                    CCIUDAD = "PROVIDENCIA",
                    RUT = 16810819,
                    TELEFONO1 = "0022751910",
                    TELEFONO2 = "0000000000"
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetPropietario(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    NOMBREPROPIETARIO = "                              ",
                    RUTPROPIETARIO = 5743405,
                    DVPROPIETARIO = "8",
                    DIRECCIONPROPIETARIO = "                              ",
                    CODIGOCOMUNA = "   ",
                    CODIGOCIUDAD = "PRO",
                    FONO = "          ",
                    EMAIL = "                                                            ",
                    PATENTE = "YC8375"
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetConductores(int numero, long numeroPoliza, string codigoSucursal, string tipoDocumento, int item, int compania)
        {
            System.Threading.Thread.Sleep(500);

            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new object[]
                {
                    new
                    {
                        NSINNIESTRO= 6354013,
                        RUTTER= -15550821,
                        DVRUTTER= "3",
                        CULPABILIDADTER= "SI",
                        NOMBRETER= "MOLINA GALDAMES ERIKA YESENIA ",
                        DIRECCIONTER= "PORTAL VALLE PASAJE BUTACO1848",
                        CODIGOCOMUNATER= "ANG",
                        CODIGOVHMARCATER= "PEU",
                        CODIGOVHMODELOTER= "00",
                        CODIGOVHVERSIONTER= "00",
                        COLORVHTER= "GRIS      ",
                        PATENTEVHTER= "SINPAT",
                        INDICIOCOMPANIATER= "SURA POL.3"
                    },
                })
            };
            return Task.FromResult(response);
        }

        public Task CompletarSiniestro(Siniestro siniestro)
        {
            System.Threading.Thread.Sleep(500);

            siniestro.TipoOrden = "OR";
            siniestro.TipoDanio = "Parcial";
            siniestro.MontoOr = 2300;
            siniestro.GastoUf = 4330;
            siniestro.Provision = 68932;
            return Task.CompletedTask;
        }



        public Task<List<FacturaViewModel>> GetFacturas(int numero, int compania)
        {

            var resultado = new List<FacturaViewModel>()
            {
                new FacturaViewModel
                {
                    RutProveedor = 89519600,
                    NombreProveedor = "AUTOMOTRIZ CPM LTDA.                                        ",
                    MontoTotal = 2296105,
                    Detalle = "PAGO REPUESTOS A PROVEEDOR                        ",
                    NumeroFactura = 1000551
                },
                new FacturaViewModel
                {
                    RutProveedor = 96924460,
                    NombreProveedor = "NO EXISTE BENEFIC.                                          ",
                    MontoTotal = 241320,
                    Detalle = "PAGO REPUESTOS A PROVEEDOR                        ",
                    NumeroFactura = 104732
                }
            };
            return Task.FromResult(resultado);
        }

        public Task<int?> GetRegion(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

            if (numero.ToString().EndsWith("0"))
                numero = numero + 1;
            return Task.FromResult((int?)Convert.ToInt32(numero.ToString().ToCharArray().Last()));
        }


        public Task<string> GetCausal(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult("CAUSAL MOCKED");
        }

        public Task<HttpResponseMessage> GetAsegurado(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

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

        public Task<HttpResponseMessage> GetLiquidador(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    RUT = 12378851,
                    DV = "6",
                    NOMBRES = "REYES ARENAS DANIEL ANTONIO",
                    CORREO = "daniel.reyes@bciseguros.com",
                    TELEFONOCOMERCIAL = 931947345,
                    TELEFONOPOSTAL = 931947345
                })
            };
            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetConductor(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

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



        public Task<HttpResponseMessage> GetVehiculo(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

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
        public Task<HttpResponseMessage> GetRelato(int numero, int compania)
        {
            System.Threading.Thread.Sleep(500);

            var response = new HttpResponseMessage()
            {
                Content = new JsonContent(new object[]
                {
                    new {
                        Linea = 0,
                        Texto = "COQ                                                                             "
                    },
                    new {
                        Linea = 1,
                        Texto = "IBA SUBIENDO POR DIEGO PORTALES Y HABÍA UN SEMÁFORO EN LUZ VERDE , ESTABAN DOS  "
                    }
                })
            };
            return Task.FromResult(response);
        }



        private static List<Siniestro> MockearSiniestros()
        {
            var siniestros = new List<Siniestro>()
            {
                new Siniestro { Riesgo = 6, Numero = 6595333, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9731422, NumeroItem = 1},
                new Siniestro { Riesgo = 6, Numero = 6630355, TipoDocumento = "P", CodigoSucursal = "W", NumeroPoliza =9891456, NumeroItem = 1},
            };
            foreach (var cadasSiniestro in siniestros)
            {
                cadasSiniestro.FechaDenuncio = new DateTime(2019, 3, 1);
                cadasSiniestro.FechaSiniestro = new DateTime(2019, 3, 1);
                cadasSiniestro.Compania = (int)TiposCompania.Bci;
                cadasSiniestro.EstadoId = (int)TiposEstado.Analisis;
            }
            return siniestros;
        }
    }
}
