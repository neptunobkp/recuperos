using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Sincronizar
{
    public class SincronizarCommandHandler : IRequestHandler<SincronizarCommand, int>
    {
        private readonly IGenerateDbContext _db;
        private readonly IApiRecup02 _importador;

        public SincronizarCommandHandler(IGenerateDbContext db, IApiRecup02 importador)
        {
            _db = db;
            _importador = importador;
        }
        public async Task<int> Handle(SincronizarCommand request, CancellationToken cancellationToken)
        {
            var cantidad = 0;

            using (var db = _db.GenerateNewContext())
            {
                for (var i = request.Desde; i <= request.Hasta; i = i.AddDays(1))
                {
                    var siniestrosImportables = await _importador.GetSeedSiniestros(i);
                    foreach (var cadaSiniestroImportable in siniestrosImportables)
                    {
                        if (db.Siniestros.Any(t => t.Numero == cadaSiniestroImportable.Numero)) continue;

                        cadaSiniestroImportable.FechaUltimoCambioEtapa = DateTime.Now;
                        cadaSiniestroImportable.FechaUltimoCambioEstado = DateTime.Now;
                        cadaSiniestroImportable.FechaUltimaActualizacion = DateTime.Now;
                        cadaSiniestroImportable.FechaImportacion = DateTime.Now;
                        cadaSiniestroImportable.Prescripcion = cadaSiniestroImportable.FechaSiniestro.GetValueOrDefault().AddMonths(5).Date;

                        await _importador.CompletarSiniestro(cadaSiniestroImportable);

                        db.Siniestros.Add(cadaSiniestroImportable);
                        await db.SaveChangesAsync(cancellationToken);
                        cantidad++;
                    }
                }
            }

            return cantidad;
        }
    }
}