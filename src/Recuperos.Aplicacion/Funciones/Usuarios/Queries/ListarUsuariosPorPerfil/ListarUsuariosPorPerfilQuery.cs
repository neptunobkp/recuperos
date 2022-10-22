using System.Collections.Generic;
using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Usuarios.Queries.ListarUsuariosPorPerfil
{
    public class ListarUsuariosPorPerfilQuery : IRequest<IEnumerable<ItemLista>>
    {
        public string Perfil { get; set; }
    }
}
