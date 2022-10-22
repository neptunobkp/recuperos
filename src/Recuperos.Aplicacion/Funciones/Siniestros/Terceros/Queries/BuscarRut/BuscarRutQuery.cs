using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarRut
{
    public class BuscarRutQuery : IRequest<RutResultViewModel>
    { 
        public int Rut { get; set; }
        public int SiniestroId { get; set; }
    }
}
