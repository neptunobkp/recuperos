using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarRutEquifax
{
    public class BuscarRutEquifaxQueryHandler : IRequestHandler<BuscarRutEquifaxQuery, RutResultEquifaxViewModel>
    {
        private readonly IApiEquifax _equifax;
        private readonly IApiConsultaDicom _consultaDicom;
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUsuarioActualService _usuarioActual;
        public BuscarRutEquifaxQueryHandler(IApiEquifax equifax, IGenerateDbContext db, IMapper mapper, IUsuarioActualService usuarioActual, IApiConsultaDicom consultaDicom)
        {
            _equifax = equifax;
            _db = db;
            _mapper = mapper;
            _usuarioActual = usuarioActual;
            _consultaDicom = consultaDicom;
        }

        public async Task<RutResultEquifaxViewModel> Handle(BuscarRutEquifaxQuery request, CancellationToken cancellationToken)
        {

            using (var db = _db.GenerateNewContext())
            {

                var vehiculoDicom = await _consultaDicom.ComprarInformacionPorRut(request.Rut);
                var vehiculoEquifax = await _equifax.ComprarInformacionPorRut(request.Rut);

                if (vehiculoDicom == null) return null;

                vehiculoEquifax.Vehiculos.ForEach(t => vehiculoDicom.Vehiculos.Add(t));
                vehiculoDicom.Vehiculos.ForEach(t => t.Patente = t.Patente.ToUpper());

                db.EntradasBitacoras.Add(new EntradaBitacora(request.SiniestroId, _usuarioActual.Id, (int)TiposCambioEstado.CambioEstado, $"Equifax, por rut {RutHelper.Rut(request.Rut)}"));
                vehiculoDicom.SiniestroId = request.SiniestroId;
                db.InfoPersonas.Add(vehiculoDicom);

                await db.SaveChangesAsync(cancellationToken);

                return _mapper.Map<RutResultEquifaxViewModel>(vehiculoDicom);

            }
        }
    }
}
