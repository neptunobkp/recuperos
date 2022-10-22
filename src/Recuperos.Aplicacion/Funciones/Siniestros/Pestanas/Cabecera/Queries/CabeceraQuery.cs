using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Cabecera.Queries
{
    public class CabeceraQuery : IRequest<SiniestroCabeceraViewModel>
    {
        public int Id { get; set; }
    }
}
