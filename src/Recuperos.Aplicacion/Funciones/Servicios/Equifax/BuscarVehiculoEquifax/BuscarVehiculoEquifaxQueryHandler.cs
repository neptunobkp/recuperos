using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarVehiculoEquifax
{
    public class BuscarVehiculoEquifaxQueryHandler : IRequestHandler<BuscarVehiculoEquifaxQuery, ResultadoPorPatenteEquifaxViewModel>
    {
        private readonly IApiEquifax _equifax;
        private readonly IApiConsultaDicom _consultaDicom;
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUsuarioActualService _usuarioActual;
        public BuscarVehiculoEquifaxQueryHandler(IApiEquifax equifax, IGenerateDbContext db, IMapper mapper, IUsuarioActualService usuarioActual, IApiConsultaDicom consultaDicom)
        {
            _equifax = equifax;
            _db = db;
            _mapper = mapper;
            _usuarioActual = usuarioActual;
            _consultaDicom = consultaDicom;
        }

        public async Task<ResultadoPorPatenteEquifaxViewModel> Handle(BuscarVehiculoEquifaxQuery request, CancellationToken cancellationToken)
        {
            request.Patente = request.Patente.ToUpper();
            using (var db = _db.GenerateNewContext())
            {
                var informacionEncontradaEnEquifax = await _consultaDicom.ComprarInformacionPorPatente(request.Patente);

                if (informacionEncontradaEnEquifax == null) return null;

                informacionEncontradaEnEquifax.Vehiculos.ForEach(t => t.Patente = t.Patente.ToUpper());

                db.EntradasBitacoras.Add(new EntradaBitacora(request.SiniestroId, _usuarioActual.Id, (int)TiposCambioEstado.CambioEstado, $"Equifax a patente {request.Patente}"));
                db.InfoPersonas.Add(informacionEncontradaEnEquifax);

                await db.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ResultadoPorPatenteEquifaxViewModel>(informacionEncontradaEnEquifax);

            }
        }
    }
}
