using System;
using MediatR;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Tipos;
using System.Threading;
using System.Threading.Tasks;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Commands.CambiarEstadoCommand.Pipelines.PreCambioEstado
{
    public class PreCambioEstadoRecuperarRegionHandler : INotificationHandler<PreCambioEstadoSiniestro>
    {
        private readonly IApiRecup02 _recup02;
        public PreCambioEstadoRecuperarRegionHandler(IApiRecup02 recup02)
        {
            _recup02 = recup02;
        }
        public async Task Handle(PreCambioEstadoSiniestro notification, CancellationToken cancellationToken)
        {
            notification.Siniestro.FechaUltimoCambioEstado = DateTime.Now;

            if (notification.Siniestro.Estado.EtapaId != notification.NuevoEstado.EtapaId)
            {
                notification.Siniestro.FechaUltimoCambioEtapa = DateTime.Now;
                notification.Siniestro.FechaAsignacion = DateTime.Now.Date;
                notification.Siniestro.EjecutivoId = null;
                if (notification.NuevoEstado.EtapaId == (int)TiposEtapa.AsignacionJudicial)
                {
                    var regionResult = await _recup02.GetRegion(notification.Siniestro.Numero, notification.Siniestro.Compania);
                    if (regionResult.HasValue)
                        notification.Siniestro.Region = regionResult;
                }
            }
            else
            {
                if (notification.Siniestro.EstadoId == (int)TiposEstado.InterCompaniaCartaEnviada ||
                    notification.Siniestro.EstadoId == (int)TiposEstado.InterCompaniaCompaniaIdentificada ||
                    notification.Siniestro.EstadoId == (int)TiposEstado.InterCompaniaPosibleCompania)
                {
                    notification.Siniestro.FechaAsignacion = DateTime.Now.Date;
                }
            }
        }
    }
}
