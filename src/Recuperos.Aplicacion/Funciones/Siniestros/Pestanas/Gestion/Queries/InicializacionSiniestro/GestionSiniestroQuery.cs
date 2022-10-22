using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.InicializacionSiniestro
{
    public class GestionSiniestroQuery : IRequest<SiniestroObtenidoGestionViewModel>
    {
        public int Id { get; set; }
    }
}
