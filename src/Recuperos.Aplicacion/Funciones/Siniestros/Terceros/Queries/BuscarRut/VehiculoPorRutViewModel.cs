using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarRut
{
    public class VehiculoPorRutViewModel : IMapFrom<InfoVehiculo>
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
            profile.CreateMap<InfoVehiculo, VehiculoPorRutViewModel>();
            profile.CreateMap<TerceroVehiculo, VehiculoPorRutViewModel>();
        }
    }
}