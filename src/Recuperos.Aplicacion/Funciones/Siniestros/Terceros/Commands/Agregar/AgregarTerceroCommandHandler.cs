using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Agregar
{
    public class AgregarTerceroCommandHandler : IRequestHandler<AgregarTerceroCommand, int>
    {
        private readonly IGenerateDbContext _db;

        public AgregarTerceroCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AgregarTerceroCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var tercero = new Tercero
                {
                    SiniestroId = request.SiniestroId,
                    Nombres = request.Nombres,
                    Rut = request.Rut,
                    Direccion = request.Direccion,
                    Alias = request.Alias,
                    Correo = request.Correo,
                    CorreoAlt = request.CorreoAlt,
                    Telefono = request.Telefono,
                    TelefonoAlt = request.TelefonoAlt,
                    EsPrincipal = request.EsPrincipal,
                    Culpabilidad = request.Culpabilidad,
                    Clasificacion = request.Clasificacion
                };

                tercero.Vehiculo = new TerceroVehiculo
                {
                    Patente = request.Patente.ToUpper(),
                    Marca = request.Marca,
                    Modelo = request.Modelo,
                    Anio = request.Anio,
                    Color = request.Color,
                    NumeroMotor = request.NumeroMotor,
                    NumeroChasis = request.NumeroChasis
                };

                db.Terceros.Add(tercero);
                await db.SaveChangesAsync(cancellationToken);

                if (request.Id > 0)
                {
                    var infoPersona = await db.InfoPersonas.FindAsync(cancellationToken, request.Id);
                    infoPersona.TerceroId = tercero.Id;
                    await db.SaveChangesAsync(cancellationToken);
                }

                return tercero.Id;
            }
        }
    }
}
