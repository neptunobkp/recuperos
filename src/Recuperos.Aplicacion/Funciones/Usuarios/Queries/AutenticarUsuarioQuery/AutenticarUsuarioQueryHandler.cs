using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Usuarios.Queries.AutenticarUsuarioQuery
{
    public class AutenticarUsuarioQueryHandler : IRequestHandler<AutenticarUsuarioQuery, UsuarioViewModel>
    {
        private readonly IGenerateDbContext _db;

        public AutenticarUsuarioQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<UsuarioViewModel> Handle(AutenticarUsuarioQuery request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var usuario = await db.Usuarios.Where(t => t.Correo == request.Correo).FirstOrDefaultAsync(cancellationToken);
                if (usuario == null || usuario.Contrasena != request.Contrasena)
                    throw new ValidationException(new ValidationFailure[] { new ValidationFailure("Contrasena", "Credenciales no válidas"), });

                return new UsuarioViewModel
                {
                    Id = usuario.Id,
                    Correo = usuario.Correo,
                    Rol = usuario.Rol,
                    Nombres = usuario.Nombres
                };
            }
        }
    }
}
