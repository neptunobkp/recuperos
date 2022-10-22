using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarVehiculoEquifax
{
    public class ResultadoPorPatenteEquifaxViewModel : IMapFrom<InfoPersona>
    {
        public ResultadoPorPatenteEquifaxViewModel()
        {
            Vehiculos = new List<VehiculoEquifaxViewModel>();
        }

        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public List<VehiculoEquifaxViewModel> Vehiculos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoPersona, ResultadoPorPatenteEquifaxViewModel>();
        }
    }
}