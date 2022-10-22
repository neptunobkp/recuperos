using MediatR;
using Recuperos.Aplicacion.Interfaces.Models;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bitacora.Queries.ObtenerBitacoraSiniestro
{
    public  class ObtenerBitacoraSiniestroQuery : IRequest<BitacoraResponseViewModel>, ISiniestroNumerable
    {
        public int Numero { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
    }
}
