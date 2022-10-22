using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;
using Recuperos.Servicios.Recup02.Models;

namespace Recuperos.Servicios.Recup02
{
    public class ApiRecup02 : IApiRecup02
    {
        private readonly HttpClient _client;
        public ApiRecup02(IRecup02HttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
        }

        public async Task<HttpResponseMessage> GetRelato(int numero, int compania) => await _client.GetAsync(Endp("relato", numero, compania));
        public async Task<HttpResponseMessage> GetConstancia(int numero, int compania) => await _client.GetAsync(Endp("constancia", numero, compania));
        public async Task<HttpResponseMessage> GetConductor(int numero, int compania) => await _client.GetAsync(Endp("conductor", numero, compania));
        public async Task<HttpResponseMessage> GetAccidente(int numero, int compania) => await _client.GetAsync(Endp("accidente", numero, compania));
        public async Task<HttpResponseMessage> GetDenunciante(int numero, int compania) => await _client.GetAsync(Endp("denunciante", numero, compania));
        public async Task<HttpResponseMessage> GetPropietario(int numero, int compania) => await _client.GetAsync(Endp("propietario", numero, compania));

        public async Task<HttpResponseMessage> GetVehiculo(int numero, int compania) => await _client.GetAsync(Endp("vehiculo", numero, compania));
        public async Task<HttpResponseMessage> GetAsegurado(int numero, int compania) => await _client.GetAsync(Endp("asegurado", numero, compania));
        public async Task<HttpResponseMessage> GetLiquidador(int numero, int compania) => await _client.GetAsync(Endp("liquidador", numero, compania));
        public async Task<List<FacturaViewModel>> GetFacturas(int numero, int compania)
        {
            var result = await _client.GetAsync(Endp("facturas", numero, compania));
            return await result.Content.ReadAsAsync<List<FacturaViewModel>>();
        }

        public async Task<HttpResponseMessage> GetConductores(int numero, long numeroPoliza, string codigoSucursal, string tipoDocumento, int item, int compania)
        {
            return await _client.GetAsync(Endp("conductores", numero, numeroPoliza, codigoSucursal, tipoDocumento, item, compania));
        }

        public async Task<int?> GetRegion(int numero, int compania)
        {
            var response = await _client.GetAsync(Endp("region", numero, compania));
            return await response.Content.ReadAsAsync<int?>();
        }

        public async Task<string> GetCausal(int numero, int compania)
        {
            var response = await _client.GetAsync(Endp("causal", numero, compania));
            return await response.Content.ReadAsAsync<string>();
        }

        public async Task<List<Siniestro>> GetSeedSiniestros(DateTime fecha)
        {
            var result = new List<Siniestro>();
            result.AddRange(await GetSiniestros(fecha, TiposCompania.Bci, "Inicializador"));
            result.AddRange(await GetSiniestros(fecha, TiposCompania.Zenit, "Inicializador"));
            return result;
        }

        public async Task CompletarSiniestro(Siniestro siniestro)
        {
            var esquemaCompnia = Esquema(siniestro.Compania);
            var response = await _client.GetAsync($"api/{esquemaCompnia}/siniestros/columnasCambiantes?numero={siniestro.Numero}&riesgo={siniestro.Riesgo}");
            var obtenerSiniestrosResponse = await response.Content.ReadAsAsync<ColumnasCambiantes>();
            if (obtenerSiniestrosResponse != null)
            {
                siniestro.TipoOrden = obtenerSiniestrosResponse.TIPOORDEN;
                siniestro.MontoOr = (int?)obtenerSiniestrosResponse.MONTOOR;
                siniestro.GastoUf = obtenerSiniestrosResponse.GASTOUF;
                siniestro.TipoDanio = DecodeTipoDanio(obtenerSiniestrosResponse.TIPODANIO);
                siniestro.Aceptado = obtenerSiniestrosResponse.ACEPTADO?.Contains("A");
                siniestro.Provision = obtenerSiniestrosResponse.PROVISION;

                if (siniestro.GastoUf < 0)
                    siniestro.GastoUf = 0;
            }
        }
        public async Task<List<Siniestro>> GetSiniestros(DateTime fecha)
        {
            var result = new List<Siniestro>();
            result.AddRange(await GetSiniestros(fecha, TiposCompania.Bci));
            result.AddRange(await GetSiniestros(fecha, TiposCompania.Zenit));
            return result;
        }
        public async Task<List<Siniestro>> GetSiniestros(DateTime fecha, TiposCompania compania, string estrategia = "migrar")
        {
            var esquemaCompnia = Esquema((int)compania);
            var result = new List<Siniestro>();
            var response = await _client.GetAsync($"api/{esquemaCompnia}/{estrategia}/pordia?dia={fecha.Day}&mes={fecha.Month}&anio={fecha.Year}");
            var obtenerSiniestrosResponse = await response.Content.ReadAsAsync<List<SiniestroImportado>>();

            foreach (var cadaSiniestro in obtenerSiniestrosResponse)
            {
                if (cadaSiniestro.An.HasValue)
                {
                    var item = new Siniestro();
                    item.Numero = cadaSiniestro.Nu;
                    item.Riesgo = cadaSiniestro.Ri;
                    item.Ramo = cadaSiniestro.Ra;
                    item.FechaSiniestro = new DateTime(cadaSiniestro.An.Value, cadaSiniestro.Me.Value, cadaSiniestro.Di.Value);
                    item.FechaDenuncio = new DateTime(cadaSiniestro.Ad, cadaSiniestro.Md, cadaSiniestro.Dd);
                    item.FechaAsignacion = DateTime.Now.Date;
                    item.Compania = (int)compania;
                    item.NumeroPoliza = cadaSiniestro.Np;
                    item.CodigoSucursal = cadaSiniestro.Co;
                    item.TipoDocumento = cadaSiniestro.Ti;
                    item.NumeroItem = cadaSiniestro.Ni;
                    item.EstadoId = cadaSiniestro.It != null && cadaSiniestro.It.ToUpper().Contains("S")
                        ? (int)TiposEstado.Analisis
                        : (int)TiposEstado.SinIndicio;
                    result.Add(item);
                }
            }
            return result;
        }

        public async Task<List<Siniestro>> GetSiniestros(int numero, TiposCompania compania)
        {
            var esquemaCompnia = Esquema((int)compania);
            var result = new List<Siniestro>();
            var response = await _client.GetAsync($"api/{esquemaCompnia}/migrar/pornumero?dia={numero}");
            var obtenerSiniestrosResponse = await response.Content.ReadAsAsync<List<SiniestroImportado>>();

            foreach (var cadaSiniestro in obtenerSiniestrosResponse)
            {
                if (cadaSiniestro.An.HasValue)
                {
                    var item = new Siniestro();
                    item.Numero = cadaSiniestro.Nu;
                    item.Riesgo = cadaSiniestro.Ri;
                    item.Ramo = cadaSiniestro.Ra;
                    item.FechaAsignacion = DateTime.Now.Date;
                    item.FechaSiniestro = new DateTime(cadaSiniestro.An.Value, cadaSiniestro.Me.Value, cadaSiniestro.Di.Value);
                    item.FechaDenuncio = new DateTime(cadaSiniestro.Ad, cadaSiniestro.Md, cadaSiniestro.Dd);
                    item.Compania = (int)compania;
                    item.NumeroPoliza = cadaSiniestro.Np;
                    item.CodigoSucursal = cadaSiniestro.Co;
                    item.TipoDocumento = cadaSiniestro.Ti;
                    item.NumeroItem = cadaSiniestro.Ni;
                    item.EstadoId = cadaSiniestro.It != null && cadaSiniestro.It.ToUpper().Contains("S")
                        ? (int)TiposEstado.Analisis
                        : (int)TiposEstado.SinIndicio;
                    result.Add(item);
                }
            }
            return result;
        }

        public string DecodeTipoDanio(string tipoDanio)
        {
            if (string.IsNullOrEmpty(tipoDanio))
                return TiposDanio.Parcial.ToString();

            if (tipoDanio.Contains("206"))
                return TiposDanio.TotalPorRobo.ToString();

            if (tipoDanio.Contains("210"))
                return TiposDanio.TotalOtroMotivo.ToString();

            return TiposDanio.Parcial.ToString();
        }


        public string Endp(string action, int numero, int compania)
        {
            return $"api/{Esquema(compania)}/siniestros/{action}?numero={numero}";
        }

        public string Endp(string action, int numero, long numeroPoliza, string codigoSucursal, string tipoDocumento, int item, int compania)
        {
            return $"api/{Esquema(compania)}/siniestros/{action}?numero={numero}&numeroPoliza={numeroPoliza}&codigoSucursal={codigoSucursal}&tipoDocumento={tipoDocumento}&item={item}";
        }


        public string Endp(string action, int compania)
        {
            return $"api/{Esquema(compania)}/siniestros/{action}";
        }

        public string Esquema(int compania)
        {
            return compania == (int)TiposCompania.Zenit ? "breton" : "concorde";
        }

    }
}
