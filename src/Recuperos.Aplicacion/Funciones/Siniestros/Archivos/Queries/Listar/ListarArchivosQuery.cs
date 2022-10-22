using System.Collections.Generic;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Listar
{
    public class ListarArchivosQuery : IRequest<IEnumerable<ArchivoAdjuntoViewModel>>
    {
        public int SiniestroId { get; set; }
    }
}
