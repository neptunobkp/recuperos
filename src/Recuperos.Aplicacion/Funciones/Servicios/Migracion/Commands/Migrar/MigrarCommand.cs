using System;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Migracion.Commands.Migrar
{
    public class MigrarCommand : IRequest<ResultadoMigracion>
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
