using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarVehiculo
{
    public class BuscarVehiculoQueryHandler : IRequestHandler<BuscarVehiculoQuery, ResultadoPorPatenteViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRnvmLocal _rnvmLocal;
        public BuscarVehiculoQueryHandler(IGenerateDbContext db, IMapper mapper, IRnvmLocal rnvmLocal)
        {
            _db = db;
            _mapper = mapper;
            _rnvmLocal = rnvmLocal;
        }

        public async Task<ResultadoPorPatenteViewModel> Handle(BuscarVehiculoQuery request, CancellationToken cancellationToken)
        {
            request.Patente = request.Patente.ToUpper();
            using (var db = _db.GenerateNewContext())
            {
                var terceroVehiculoExistente = await db.VehiculosTercero
                    .Include(t => t.Tercero)
                    .Where(t => t.Patente.Contains(request.Patente))
                    .OrderByDescending(t => t.TerceroVehiculoId)
                    .Take(1)
                    .FirstOrDefaultAsync(cancellationToken);

                if (terceroVehiculoExistente != null)
                {
                    return new ResultadoPorPatenteViewModel
                    {
                        Rut = terceroVehiculoExistente.Tercero?.Rut.ToString(),
                        Nombres = terceroVehiculoExistente.Tercero?.Nombres,
                        Correo = terceroVehiculoExistente.Tercero?.Correo,
                        CorreoAlt = terceroVehiculoExistente.Tercero?.CorreoAlt,
                        Direccion = terceroVehiculoExistente.Tercero?.Direccion,
                        Telefono = terceroVehiculoExistente.Tercero?.Telefono,
                        TelefonoAlt = terceroVehiculoExistente.Tercero?.TelefonoAlt,
                        Vehiculos = new List<VehiculoPorPatenteViewModel>
                        {
                            _mapper.Map<VehiculoPorPatenteViewModel>(terceroVehiculoExistente)
                        }
                    };
                }

                var infoVehiculoExistente = await db.InfoVehiculos
                    .Include(t => t.InfoPersona)
                    .Where(t => t.Patente.Contains(request.Patente))
                    .OrderByDescending(t => t.FechaConsulta)
                    .Take(1)
                    .FirstOrDefaultAsync(cancellationToken);

                if (infoVehiculoExistente != null)
                    return new ResultadoPorPatenteViewModel
                    {
                        Rut = infoVehiculoExistente.InfoPersona?.Rut.ToString(),
                        Nombres = infoVehiculoExistente.InfoPersona?.Nombres,
                        Vehiculos = new List<VehiculoPorPatenteViewModel>
                        {
                            _mapper.Map<VehiculoPorPatenteViewModel>(infoVehiculoExistente)
                        }
                    };


                var personaEnRnvm = await _rnvmLocal.ObtenerInformacionPorPatente(request.Patente);
                if (personaEnRnvm != null)
                    return new ResultadoPorPatenteViewModel
                    {
                        Rut = personaEnRnvm.Rut.ToString(),
                        Nombres = personaEnRnvm.Nombres,
                        Correo = personaEnRnvm.Correo,
                        Telefono = personaEnRnvm.Telefono,
                        Direccion = personaEnRnvm.Direccion,
                        Vehiculos = new List<VehiculoPorPatenteViewModel>
                        {
                            _mapper.Map<VehiculoPorPatenteViewModel>(personaEnRnvm.Vehiculos.First())
                        }
                    };

                return null;
            }
        }
    }
}
