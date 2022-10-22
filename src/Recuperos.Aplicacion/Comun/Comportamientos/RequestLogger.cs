using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Models;

namespace Recuperos.Aplicacion.Comun.Comportamientos
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IUsuarioActualService _usuarioActual;
        public RequestLogger(IUsuarioActualService usuarioActual)
        {
            _usuarioActual = usuarioActual;
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger(typeof(TRequest));
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var identificable = request as ISiniestroIdentificable;
            if (identificable != null)
            {
                Log(request, identificable.Id);
                return Task.CompletedTask;
            }

            var numerable = request as ISiniestroNumerable;
            if (numerable != null)
            {
                Log(request, numerable.Numero);
                return Task.CompletedTask;
            }

            Log(request);
            return Task.CompletedTask;
        }

        private void Log(TRequest request, int siniestroId = 0)
        {
            Logger
                .WithProperty("UsuarioId", _usuarioActual.Id)
                .WithProperty("SiniestroId", siniestroId)
                .Info(request);
        }
    }
}
