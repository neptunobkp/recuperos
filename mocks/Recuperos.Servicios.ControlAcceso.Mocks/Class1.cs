using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso.Modelos;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Servicios.ControlAcceso.Mocks
{
    public class ApiControlAccesoMock : IControlAcceso
    {

        private readonly Usuario _usuario;
        public ApiControlAccesoMock(Usuario usuario)
        {
            _usuario = usuario;
        }

        public Task<LoginResponse> Autenticar(string rut, string contrasena)
        {
            return Task.FromResult<LoginResponse>(new LoginResponse
            {
                ContrasenaCorrecta = _usuario != null,
                RolesUsuario = new ItemRol[] { new ItemRol
                {
                    Descripcion = _usuario?.Rol
                }}
            });
        }

        public Task<UsuarioResponse> ObtenerUsuario(int id, string token)
        {
            return Task.FromResult(new UsuarioResponse());
        }
    }
}
