using MediatR;

namespace Recuperos.Aplicacion.Funciones.Usuarios.Queries.AutenticarUsuarioQuery
{
    public class AutenticarUsuarioQuery : IRequest<UsuarioViewModel>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}
