using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Servicios.Recup02.Mocks
{
    public class ApiMigracionMock : IApiMigracion
    {
        public Task<List<Siniestro>> GetSeedSiniestros(DateTime fecha)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult(new List<Siniestro>());
        }

        public Task<EstadoImportado> GetEstado(int numero)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult(new EstadoImportado());
        }

        public Task<List<ObservacionImportada>> GetObservaciones(int numero)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult(new List<ObservacionImportada>());

        }

        public Task<List<BitacoraImportada>> GetBitacora(int numero)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult(new List<BitacoraImportada>());
        }

        public Task<List<TerceroImportado>> GetTerceros(int numero)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult(new List<TerceroImportado>());
        }

        public Task<VehiculoImportado> GetVehiculo(int numero, int propietarioId)
        {
            System.Threading.Thread.Sleep(500);

            return Task.FromResult(new VehiculoImportado());
        }

        public Task<Siniestro> GetSiniestro(int numero, TiposCompania compania)
        {
            return Task.FromResult(new Siniestro());
        }
    }
}