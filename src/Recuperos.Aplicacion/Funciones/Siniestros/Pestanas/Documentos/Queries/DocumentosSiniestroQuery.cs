using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Documentos.Queries
{
    public class DocumentosSiniestroQuery : IRequest<SiniestroDocumentoViewModel>
    {
        public int Id { get; set; }
    }
}
