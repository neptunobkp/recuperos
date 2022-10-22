using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using System.Data.Entity;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Editar
{
    public class EditarTerceroCommandHandler : IRequestHandler<EditarTerceroCommand>
    {
        private readonly IGenerateDbContext _db;

        public EditarTerceroCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(EditarTerceroCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var tercero = await db.Terceros.Include(t => t.Vehiculo).SingleAsync(t => t.Id == request.Id, cancellationToken);

                if (request.Rut > 0)
                    tercero.Rut = request.Rut;
                tercero.Nombres = request.Nombres;
                tercero.Direccion = request.Direccion;
                tercero.Correo = request.Correo;
                tercero.CorreoAlt = request.CorreoAlt;
                tercero.Telefono = request.Telefono;
                tercero.TelefonoAlt = request.TelefonoAlt;
                tercero.EsPrincipal = request.EsPrincipal;
                tercero.Alias = request.Alias;
                tercero.Culpabilidad = request.Culpabilidad;
                tercero.Clasificacion = request.Clasificacion;

                if (tercero.Vehiculo == null)
                    tercero.Vehiculo = new TerceroVehiculo();

                tercero.Vehiculo.Patente = request.Patente?.ToUpper();
                tercero.Vehiculo.Marca = request.Marca;
                tercero.Vehiculo.Modelo = request.Modelo;
                tercero.Vehiculo.Anio = request.Anio;
                tercero.Vehiculo.Color = request.Color;
                tercero.Vehiculo.NumeroMotor = request.NumeroMotor;
                tercero.Vehiculo.NumeroChasis = request.NumeroChasis;

                await db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
