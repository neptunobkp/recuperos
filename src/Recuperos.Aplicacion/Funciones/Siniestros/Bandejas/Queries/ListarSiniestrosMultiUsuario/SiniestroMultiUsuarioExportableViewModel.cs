using System;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public class SiniestroMultiUsuarioExportableViewModel : IMapFrom<Siniestro>
    {
        public SiniestroMultiUsuarioExportableViewModel()
        {
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Riesgo { get; set; }
        public string FechaDenuncio { get; set; }
        public string FechaSiniestro { get; set; }
        public string Prescripcion { get; set; }
        public string FechaImportacion { get; set; }
        public string Probabilidad { get; set; }
        public string Compania { get; set; }
        public int? Provision { get; set; }
        public int? GastoUf { get; set; }
        public int? MontoOr { get; set; }
        public string FechaAsignacion { get; set; }
        public string EjecutivoNombre { get; set; }
        public int? DiasGestion { get; set; }
        public string AlertaGestion { get; set; }
        public string EstadoNombre { get; set; }
        public string NumeroPoliza { get; set; }
        public string TipoDanio { get; set; }
        public string TipoOrden { get; set; }
        public bool Alertado { get; set; }
        public int? DiasAlerta { get; set; }
        public string CompaniaTercero { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroMultiUsuarioExportableViewModel>()
                .ForMember(dest => dest.DiasGestion, opt => opt.MapFrom(src => (int?)(DateTime.Now - src.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays))
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => ((TiposCompania)src.Compania).ToString()))
                .ForMember(dest => dest.Probabilidad, opt => opt.MapFrom(src => ((TiposProbabilidad)src.Probabilidad).GetDescription()));
        }
    }
}