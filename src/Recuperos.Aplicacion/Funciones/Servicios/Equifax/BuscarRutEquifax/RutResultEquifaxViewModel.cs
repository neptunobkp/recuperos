using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarRutEquifax
{
    public class RutResultEquifaxViewModel : IMapFrom<InfoVehiculo>
    {
        public RutResultEquifaxViewModel()
        {
            Vehiculos = new List<RutResultVehiculoEquifaxViewModel>();
        }

        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public List<RutResultVehiculoEquifaxViewModel> Vehiculos { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoPersona, RutResultEquifaxViewModel>();
        }
    }
}
