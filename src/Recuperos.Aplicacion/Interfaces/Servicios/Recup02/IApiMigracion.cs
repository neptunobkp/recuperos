using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Interfaces.Servicios.Recup02
{
    public interface IApiMigracion
    {
        Task<List<Siniestro>> GetSeedSiniestros(DateTime fecha);
        Task<EstadoImportado> GetEstado(int numero);
        Task<List<ObservacionImportada>> GetObservaciones(int numero);
        Task<List<BitacoraImportada>> GetBitacora(int numero);

        Task<List<TerceroImportado>> GetTerceros(int numero);
        Task<VehiculoImportado> GetVehiculo(int numero, int propietarioId);

        Task<Siniestro> GetSiniestro(int numero, TiposCompania compania);
    }
}