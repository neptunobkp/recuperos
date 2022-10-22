using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Documentos.Queries
{
    public class SiniestroDocumentoViewModel : IMapFrom<Siniestro>
    {
        public string Numero { get; set; }
        public string Compania { get; set; }
        public string EjecutivoNombre { get; set; }
        public string EstadoNombre { get; set; }
        public string Probabilidad { get; set; }
        public string UrlCm { get; set; }
        public string Fotos { get; set; }
        public string Antecedentes { get; set; }
        public string Poliza { get; set; }
        public string OrdenReparacion { get; set; }
        public string Facturas { get; set; }
        public bool PendienteVisado { get; set; }
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroDocumentoViewModel>()
                .ForMember(dest => dest.PendienteVisado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value > 0))
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => ((TiposCompania)src.Compania).ToString()))
                .ForMember(dest => dest.Probabilidad, opt => opt.MapFrom(src => ((TiposProbabilidad)src.Probabilidad).GetDescription()));
        }
    }
}