using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarRutEquifax
{
    public class RutResultVehiculoEquifaxViewModel : IMapFrom<InfoVehiculo>
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoVehiculo, RutResultVehiculoEquifaxViewModel>();
        }
    }
}