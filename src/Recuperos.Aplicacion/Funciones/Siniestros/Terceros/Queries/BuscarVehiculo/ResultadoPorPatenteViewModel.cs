using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarVehiculo
{
    public class ResultadoPorPatenteViewModel : IMapFrom<InfoVehiculo>
    {
        public ResultadoPorPatenteViewModel()
        {
            Vehiculos = new List<VehiculoPorPatenteViewModel>();
        }

        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }
        public string TelefonoAlt { get; set; }
        public string Telefono { get; set; }
        public List<VehiculoPorPatenteViewModel> Vehiculos { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tercero, ResultadoPorPatenteViewModel>();
        }
    }
}
