using System;
using System.Collections.Generic;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.Permisos;
using Recuperos.Aplicacion.Models;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.InicializacionSiniestro
{
    public class SiniestroObtenidoGestionViewModel : IMapFrom<Siniestro>
    {
        public SiniestroObtenidoGestionViewModel()
        {
            Permisos = new ListaPermisos();
            EstadosTransicion = new List<ItemsLista>();
        }

        public string Numero { get; set; }
        public string Compania { get; set; }
        public string EjecutivoNombres { get; set; }
        public int? EjecutivoId { get; set; }
        public string EstadoNombre { get; set; }
        public int EstadoId { get; set; }
        public string ProbabilidadDesc { get; set; }
        public string Probabilidad { get; set; }


        public string CompaniaTercero { get; set; }
        public int? NumeroTercero { get; set; }
        public DateTime? FechaPromesa { get; set; }
        public int? Monto { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaCarta { get; set; }
        public int? MontoSolicitado { get; set; }
        public string EstudioAbogados { get; set; }

        public List<ItemsLista> EstadosTransicion { get; set; }
        public ListaPermisos Permisos { get; set; }

        public bool PendienteVisado { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroObtenidoGestionViewModel>()
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => ((TiposCompania)src.Compania).GetDescription()))
                .ForMember(dest => dest.PendienteVisado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value > 0))
                .ForMember(dest => dest.ProbabilidadDesc, opt => opt.MapFrom(src => ((TiposProbabilidad)src.Probabilidad).GetDescription()));
        }
    }
}
