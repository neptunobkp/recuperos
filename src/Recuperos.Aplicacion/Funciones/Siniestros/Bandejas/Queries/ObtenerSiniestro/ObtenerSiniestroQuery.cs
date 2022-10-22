using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ObtenerSiniestro
{
    public class ObtenerSiniestroQuery : IRequest<SiniestroObtenidoViewModel>
    {
        public int SiniestroId { get; set; }
    }
}
