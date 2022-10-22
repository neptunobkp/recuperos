using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarRut
{
    public class BuscarRutQueryHandler : IRequestHandler<BuscarRutQuery, RutResultViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRnvmLocal _rnvmLocal;
        public BuscarRutQueryHandler(IGenerateDbContext db, IMapper mapper, IRnvmLocal rnvmLocal)
        {
            _db = db;
            _mapper = mapper;
            _rnvmLocal = rnvmLocal;
        }

        public async Task<RutResultViewModel> Handle(BuscarRutQuery request, CancellationToken cancellationToken)
        {

            using (var db = _db.GenerateNewContext())
            {
                var tercero = await BuscarEnTerceros(request, cancellationToken, db);
                if (tercero != null)
                    return Mapear(tercero);

                var datoComprado = await BuscarEnDatosComprados(request, cancellationToken, db);
                if (datoComprado != null)
                    return _mapper.Map<RutResultViewModel>(datoComprado);

                var personaEnRnvm = await _rnvmLocal.ObtenerInformacionPorRut(request.Rut);
                if (personaEnRnvm != null)
                    return _mapper.Map<RutResultViewModel>(personaEnRnvm);

                return null;
            }
        }

        private static async Task<InfoPersona> BuscarEnDatosComprados(BuscarRutQuery request, CancellationToken cancellationToken, IAppDbContext db)
        {
            return await db.InfoPersonas
                .Include(t => t.Vehiculos)
                .Where(t => t.Rut == request.Rut)
                .OrderByDescending(t => t.FechaConsulta)
                .Take(1)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private RutResultViewModel Mapear(Tercero tercero)
        {
            var rutResult = _mapper.Map<RutResultViewModel>(tercero);
            rutResult.Vehiculos = new List<VehiculoPorRutViewModel>
            {
                _mapper.Map<VehiculoPorRutViewModel>(tercero.Vehiculo)
            };
            return rutResult;
        }

        private static async Task<Tercero> BuscarEnTerceros(BuscarRutQuery request, CancellationToken cancellationToken, IAppDbContext db)
        {
            return await db.Terceros
                .Include(t => t.Vehiculo)
                .Where(t => t.Rut == request.Rut)
                .OrderByDescending(t => t.Id)
                .Take(1)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
