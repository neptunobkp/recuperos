using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Interfaces.Servicios.Recup02
{
    public interface IApiRecup02
    {
        Task<List<Siniestro>> GetSiniestros(DateTime fecha);
        Task<List<Siniestro>> GetSiniestros(int numero, TiposCompania compania);

        Task<List<Siniestro>> GetSeedSiniestros(DateTime fecha);
        Task<HttpResponseMessage> GetRelato(int numero, int compania);
        Task<HttpResponseMessage> GetConstancia(int numero, int compania);
        Task<HttpResponseMessage> GetAsegurado(int numero, int compania);
        Task<HttpResponseMessage> GetVehiculo(int numero, int compania);
        Task<HttpResponseMessage> GetLiquidador(int numero, int compania);
        Task<HttpResponseMessage> GetConductor(int numero, int compania);
        Task<HttpResponseMessage> GetAccidente(int numero, int compania);
        Task<HttpResponseMessage> GetDenunciante(int numero, int compania);
        Task<HttpResponseMessage> GetPropietario(int numero, int compania);
        Task<HttpResponseMessage> GetConductores(int numero, long numeroPoliza, string codigoSucursal, string tipoDocumento, int item, int compania);

        Task<string> GetCausal(int numero, int compania);

        Task CompletarSiniestro(Siniestro siniestro);
        Task<List<FacturaViewModel>> GetFacturas(int numero, int compania);
        Task<int?> GetRegion(int numero, int compania);

    }
}
