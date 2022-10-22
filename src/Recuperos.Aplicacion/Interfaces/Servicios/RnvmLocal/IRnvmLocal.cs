using System.Threading.Tasks;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal
{
    public interface IRnvmLocal
    {
        Task<InfoPersona> ObtenerInformacionPorPatente(string patente);
        Task<InfoPersona> ObtenerInformacionPorRut(int rut);
    }
}
