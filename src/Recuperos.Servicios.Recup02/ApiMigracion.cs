using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Servicios.Recup02
{
    public class ApiMigracion : IApiMigracion
    {
        private readonly HttpClient _client;
        public ApiMigracion(IRecup02HttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
        }

        public async Task<List<Siniestro>> GetSeedSiniestros(DateTime fecha)
        {
            var result = new List<Siniestro>();
            result.AddRange(await GetSiniestros(fecha, TiposCompania.Bci));
            result.AddRange(await GetSiniestros(fecha, TiposCompania.Zenit));
            return result;
        }

        public async Task<Siniestro> GetSiniestro(int numero, TiposCompania compania)
        {
            var esquemaCompnia = Esquema((int)compania);
            var response = await _client.GetAsync($"api/importador/pornumero?compania={esquemaCompnia}&numero={numero}");
            var obtenerSiniestrosResponse = await response.Content.ReadAsAsync<List<SiniestroImportado>>();

            foreach (var cadaSiniestro in obtenerSiniestrosResponse)
            {
                if (cadaSiniestro.An.HasValue)
                {
                    var item = new Siniestro();
                    item.Numero = cadaSiniestro.Nu;
                    item.Riesgo = cadaSiniestro.Ri;
                    item.FechaSiniestro = new DateTime(cadaSiniestro.An.Value, cadaSiniestro.Me.Value, cadaSiniestro.Di.Value);
                    item.FechaDenuncio = new DateTime(cadaSiniestro.Ad, cadaSiniestro.Md, cadaSiniestro.Dd);
                    item.FechaAsignacion = DateTime.Now.Date;
                    item.Compania = (int)compania;
                    item.NumeroPoliza = cadaSiniestro.Np;
                    item.CodigoSucursal = cadaSiniestro.Co;
                    item.TipoDocumento = cadaSiniestro.Ti;
                    item.NumeroItem = cadaSiniestro.Ni;

                    return item;
                }
            }

            return null;
        }

        public async Task<List<Siniestro>> GetSiniestros(DateTime fecha, TiposCompania compania)
        {
            var esquemaCompnia = Esquema((int)compania);
            var result = new List<Siniestro>();
            var response = await _client.GetAsync($"api/importador/pordia?compania={esquemaCompnia}&dia={fecha.Day}&mes={fecha.Month}&anio={fecha.Year}");
            var obtenerSiniestrosResponse = await response.Content.ReadAsAsync<List<SiniestroImportado>>();

            foreach (var cadaSiniestro in obtenerSiniestrosResponse)
            {
                if (cadaSiniestro.An.HasValue)
                {
                    var item = new Siniestro();
                    item.Numero = cadaSiniestro.Nu;
                    item.Riesgo = cadaSiniestro.Ri;
                    item.FechaSiniestro = new DateTime(cadaSiniestro.An.Value, cadaSiniestro.Me.Value, cadaSiniestro.Di.Value);
                    item.FechaDenuncio = new DateTime(cadaSiniestro.Ad, cadaSiniestro.Md, cadaSiniestro.Dd);
                    item.Compania = (int)compania;
                    item.NumeroPoliza = cadaSiniestro.Np;
                    item.CodigoSucursal = cadaSiniestro.Co;
                    item.TipoDocumento = cadaSiniestro.Ti;
                    item.NumeroItem = cadaSiniestro.Ni;

                    result.Add(item);
                }
            }
            return result;
        }

        public async Task<EstadoImportado> GetEstado(int numero)
        {
            var responseEstadoImportado = await _client.GetAsync($"api/importador/estado?numero={numero}");
            return await responseEstadoImportado.Content.ReadAsAsync<EstadoImportado>();
        }

        public async Task<List<ObservacionImportada>> GetObservaciones(int numero)
        {
            var responseEstadoImportado = await _client.GetAsync($"api/importador/observaciones?numero={numero}");
            return await responseEstadoImportado.Content.ReadAsAsync<List<ObservacionImportada>>();
        }

        public async Task<List<BitacoraImportada>> GetBitacora(int numero)
        {
            var responseEstadoImportado = await _client.GetAsync($"api/importador/bitacora?numero={numero}");
            return await responseEstadoImportado.Content.ReadAsAsync<List<BitacoraImportada>>();
        }

        public async Task<List<TerceroImportado>> GetTerceros(int numero)
        {
            var responseEstadoImportado = await _client.GetAsync($"api/importador/tercero?numero={numero}");
            return await responseEstadoImportado.Content.ReadAsAsync<List<TerceroImportado>>();
        }

        public async Task<VehiculoImportado> GetVehiculo(int numero, int propietarioId)
        {
            var responseEstadoImportado = await _client.GetAsync($"api/importador/vehiculo?numero={numero}&idpropietario={propietarioId}");
            return await responseEstadoImportado.Content.ReadAsAsync<VehiculoImportado>();
        }

        public string Esquema(int compania)
        {
            return compania == (int)TiposCompania.Zenit ? "breton" : "concorde";
        }
    }
}
