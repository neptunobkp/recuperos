using System;
using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Models;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ObtenerSiniestro
{
    public class SiniestroObtenidoViewModel : IMapFrom<Siniestro>
    {
        public SiniestroObtenidoViewModel()
        {
            EstadosTransicion = new List<ItemLista>();
        }

        public string AlertaGestion { get; set; }
        public string Causal { get; set; }
        public string Compania { get; set; }
        public string CompaniaTercero { get; set; }
        public int? DiasGestion { get; set; }
        public string EjecutivoNombres { get; set; }
        public string EstadoNombre { get; set; }
        public List<ItemLista> EstadosTransicion { get; set; }
        public string EstudioAbogados { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaDenuncio { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        public int? GastoUf { get; set; }
        public int Id { get; set; }
        public int? MontoOr { get; set; }
        public int Numero { get; set; }
        public string NumeroPoliza { get; set; }
        public int Probabilidad { get; set; }
        public string ProbabilidadDesc { get; set; }
        public int? Provision { get; set; }
        public int Riesgo { get; set; }
        public string TipoDanio { get; set; }
        public string TipoOrden { get; set; }
        public bool PendienteVisado { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroObtenidoViewModel>()
                .ForMember(dest => dest.PendienteVisado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value > 0))
                .ForMember(dest => dest.NumeroPoliza, opt => opt.MapFrom(cadaSiniestro => $"{cadaSiniestro.CodigoSucursal}-{cadaSiniestro.TipoDocumento}-{cadaSiniestro.NumeroPoliza}-{cadaSiniestro.NumeroItem}"))
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => ((TiposCompania)src.Compania).GetDescription()))
                .ForMember(dest => dest.ProbabilidadDesc, opt => opt.MapFrom(src => src.Probabilidad == (int)TiposProbabilidad.Indefinida ? string.Empty : ((TiposProbabilidad)src.Probabilidad).ToString()));
        }
    }
}