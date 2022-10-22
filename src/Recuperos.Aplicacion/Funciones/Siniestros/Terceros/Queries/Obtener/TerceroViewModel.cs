using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Obtener
{
    public class TerceroViewModel : IMapFrom<Tercero>
    {
        public int Id { get; set; }
        public int SiniestroId { get; set; }
        public string Nombres { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAlt { get; set; }
        public string Alias { get; set; }
        public bool EsPrincipal { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }

        public string Clasificacion { get; set; }
        public string Culpabilidad { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tercero, TerceroViewModel>()
                .ForMember(dest => dest.Rut, opt => opt.MapFrom(src => RutHelper.Rut(src.Rut)))
                .ForMember(dest => dest.Patente, opt => opt.MapFrom(src => VehiculoPatente(src)))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => VehiculoMarca(src)))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => VehiculoModelo(src)))
                .ForMember(dest => dest.Anio, opt => opt.MapFrom(src => VehiculoAnio(src)))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => VehiculoColor(src)))
                .ForMember(dest => dest.NumeroMotor, opt => opt.MapFrom(src => VehiculoNumeroMotor(src)))
                .ForMember(dest => dest.NumeroChasis, opt => opt.MapFrom(src => VehiculoNumeroChasis(src)))
                ;
        }

        private static string VehiculoNumeroChasis(Tercero src) => src.Vehiculo?.NumeroChasis;
        private static string VehiculoNumeroMotor(Tercero src) => src.Vehiculo?.NumeroMotor;
        private static string VehiculoColor(Tercero src) => src.Vehiculo?.Color;
        private static int? VehiculoAnio(Tercero src) => src.Vehiculo?.Anio;
        private static string VehiculoModelo(Tercero src) => src.Vehiculo?.Modelo;
        private static string VehiculoMarca(Tercero src) => src.Vehiculo?.Marca;
        private static string VehiculoPatente(Tercero src) => src.Vehiculo?.Patente;
    }
}
