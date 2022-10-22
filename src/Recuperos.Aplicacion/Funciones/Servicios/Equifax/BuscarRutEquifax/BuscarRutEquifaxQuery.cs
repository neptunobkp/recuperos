using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarRutEquifax
{
    public class BuscarRutEquifaxQuery : IRequest<RutResultEquifaxViewModel>
    { 
        public int Rut { get; set; }
        public int SiniestroId { get; set; }
    }
}
