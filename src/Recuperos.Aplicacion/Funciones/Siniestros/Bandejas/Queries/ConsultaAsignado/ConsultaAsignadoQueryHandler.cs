using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ConsultaAsignado
{
    public class ConsultaAsignadoQueryHandler : IRequestHandler<ConsultaAsignadoQuery, SiniestroAsignadoViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IUsuarioActualService _usuarioActual;

        public ConsultaAsignadoQueryHandler(IGenerateDbContext db, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _usuarioActual = usuarioActual;
        }

        public async Task<SiniestroAsignadoViewModel> Handle(ConsultaAsignadoQuery request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var siniestro = await db.Siniestros
                    .Include(t => t.Ejecutivo)
                    .Include(t => t.Estado.Etapa)
                    .AsNoTracking().FirstOrDefaultAsync(t => t.Numero == request.Numero, cancellationToken);
                if (siniestro == null) return new SiniestroAsignadoViewModel { Respuesta = "Siniestro no encontrado" };

                if (string.IsNullOrEmpty(siniestro.Ejecutivo?.Nombres))
                    return new SiniestroAsignadoViewModel { Respuesta = $"Siniestro en {siniestro.Estado.Etapa.Nombre} no asignado." };

                if (siniestro.EjecutivoId != _usuarioActual.Id && string.Compare(_usuarioActual.Rol, TiposRol.EstudioJuridicoExtern, StringComparison.InvariantCultureIgnoreCase) == 0)
                    return new SiniestroAsignadoViewModel { Respuesta = $"Este siniestro en {siniestro.Estado.Etapa.Nombre} no se encuentra asignado a este perfil." };

                return new SiniestroAsignadoViewModel { Respuesta = $"Siniestro en {siniestro.Estado.Etapa.Nombre}, asignado a {siniestro.Ejecutivo.Nombres}" };
            }
        }
    }
}