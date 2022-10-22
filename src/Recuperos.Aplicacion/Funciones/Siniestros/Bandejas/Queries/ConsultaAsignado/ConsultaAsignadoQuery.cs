using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ConsultaAsignado
{
    public class ConsultaAsignadoQuery : IRequest<SiniestroAsignadoViewModel>
    {
        public int Numero { get; set; }
    }
}
