using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Usuarios.Queries.ListarUsuariosPorPerfil
{
    public class ListarUsuariosPorPerfilQueryHandler : IRequestHandler<ListarUsuariosPorPerfilQuery, IEnumerable<ItemLista>>
    {
        private readonly IGenerateDbContext _db;

        public ListarUsuariosPorPerfilQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ItemLista>> Handle(ListarUsuariosPorPerfilQuery request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                if (request.Perfil == "PrejudicialInterno")
                {
                    var usuarios = await db.Usuarios.AsNoTracking().Where(t => t.Rol.Contains("PrejudicialInter")).ToListAsync(cancellationToken);
                    return usuarios.OrderBy(t => t.Nombres).Select(t => new ItemLista { Id = t.Id.ToString(), Nombre = t.Nombres });
                }
                else
                {
                    var usuarios = await db.Usuarios.AsNoTracking().Where(t => t.Rol.Contains(request.Perfil)).ToListAsync(cancellationToken);
                    return usuarios.OrderBy(t => t.Nombres).Select(t => new ItemLista { Id = t.Id.ToString(), Nombre = t.Nombres });
                }
            }
        }
    }
}