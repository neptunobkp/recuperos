using System;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Sincronizar
{
    public class SincronizarCommand : IRequest<int>
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
