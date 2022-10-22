using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso.Modelos;

namespace Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso
{
    public interface IControlAcceso
    {
        Task<LoginResponse> Autenticar(string rut, string contrasena);

        Task<UsuarioResponse> ObtenerUsuario(int id, string token);
    }
}
