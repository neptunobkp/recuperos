using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal.Models;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Listar
{
    public class DireccionViewModel : IMapFrom<InfoDireccion>
    {
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Referencia { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoDireccion, DireccionViewModel>();
        }
    }

    public class TelefonoViewModel : IMapFrom<InfoTelefono>
    {
        public string CodigoPais { get; set; }
        public string CodigoArea { get; set; }
        public string Numero { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoTelefono, TelefonoViewModel>();
        }
    }

    public class CorreoViewModel : IMapFrom<InfoCorreo>
    {
        public string Correo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<InfoCorreo, CorreoViewModel>();
        }
    }

    public class ItemListableTerceroViewModel : IMapFrom<Tercero>
    {
        public ItemListableTerceroViewModel()
        {
            Direcciones = new List<DireccionViewModel>();
            Telefonos = new List<TelefonoViewModel>();
            Correos = new List<CorreoViewModel>();
        }

        public List<DireccionViewModel> Direcciones { get; set; }
        public List<TelefonoViewModel> Telefonos { get; set; }
        public List<CorreoViewModel> Correos { get; set; }

        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }
        public string TelefonoAlt { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string VehiculoPatente { get; set; }
        public string VehiculoMarca { get; set; }
        public string VehiculoModelo { get; set; }
        public string VehiculoAnio { get; set; }
        public string VehiculoColor { get; set; }
        public string VehiculoNumeroMotor { get; set; }
        public string VehiculoNumeroChasis { get; set; }

        public string Alias { get; set; }

        public bool EsPrincipal { get; set; }

        public string ClasificacionDesc { get; set; }
        public string CulpabilidadDesc { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tercero, ItemListableTerceroViewModel>()
                .ForMember(dest => dest.ClasificacionDesc, opt => opt.MapFrom(src =>  GetClasificacionDescription(src)))
                .ForMember(dest => dest.CulpabilidadDesc, opt => opt.MapFrom(src => GetCulpabilidadDescription(src)));
        }

        private static string GetClasificacionDescription(Tercero src)
        {
            if (!src.Clasificacion.HasValue) 
                return string.Empty;
            return ((TiposClasificacionTercero)src.Clasificacion).GetDescription();
        }

        private static string GetCulpabilidadDescription(Tercero src)
        {
            if (!src.Culpabilidad.HasValue)
                return string.Empty;
            return ((TiposCulpabilidadTercero) src.Culpabilidad).GetDescription();
        }
    }
}
