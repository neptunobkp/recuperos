using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarRut
{
    public class RutResultViewModel : IMapFrom<InfoPersona>
    {
        public RutResultViewModel()
        {
            Vehiculos = new List<VehiculoPorRutViewModel>();
        }

        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAlt { get; set; }
        public bool EsPrincipal { get; set; }
        public List<VehiculoPorRutViewModel> Vehiculos { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoPersona, RutResultViewModel>();
            profile.CreateMap<Tercero, RutResultViewModel>();
        }
    }
}
