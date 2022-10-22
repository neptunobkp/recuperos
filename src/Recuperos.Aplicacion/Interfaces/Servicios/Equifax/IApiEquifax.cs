using System.Threading.Tasks;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Interfaces.Servicios.Equifax
{
    public interface IApiEquifax
    {
        Task<InfoPersona> ComprarInformacionPorPatente(string patente);
        Task<InfoPersona> ComprarInformacionPorRut(int rut);
    }

    public interface IApiConsultaDicom
    {
        Task<InfoPersona> ComprarInformacionPorPatente(string patente);
        Task<InfoPersona> ComprarInformacionPorRut(int rut);
    }
}
