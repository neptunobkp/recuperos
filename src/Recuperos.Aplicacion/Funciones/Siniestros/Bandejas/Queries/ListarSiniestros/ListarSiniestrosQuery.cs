using System;
using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestros.Propiedades;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario;
using Recuperos.Modelo.Queries;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestros
{
    public class ListarSiniestrosQuery : IRequest<FilasSiniestroViewModel>
    {
        public int EtapaId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
        public string Direccion { get; set; }
        public FiltroSiniestros Filtros { get; set; }
    }


    public class FilasSiniestroViewModel
    {
        public List<FilaSiniestroViewModel> Items { get; set; }
        public int Total { get; set; }
        public int TotalGlobal { get; set; }
    }

    public class FilaSiniestroViewModel : IMapFrom<QSiniestro>
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Compania { get; set; }
        public int Riesgo { get; set; }
        public DateTime? FechaDenuncio { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public int? EjecutivoId { get; set; }
        public string EjecutivoNombres { get; set; }
        public DateTime? FechaUltimoCambioEstado { get; set; }

        public int? EstadoId { get; set; }
        public int EtapaId { get; set; }
        public int? EstadoDiasAlerta { get; set; }
        public string EstadoNombre { get; set; }
        public string CompaniaTercero { get; set; }
        public int? Region { get; set; }
        public int? DiasGestion { get; set; }
        public int? AlertaGestion { get; set; }

        public int Probabilidad { get; set; }
        public int? Prescripcion { get; set; }
        public string Daterc { get; set; }


        public string ActualizadoPor { get; set; }
        public string EstadoDestinoNombre { get; set; }


        public decimal? GastoUf { get; set; }
        public decimal? MontoOr { get; set; }
        public decimal? Provision { get; set; }

        public string Aceptado { get; set; }
        public string TipoOrden { get; set; }
        public string TipoDanio { get; set; }

        public bool PendienteVisado { get; set; }
        public bool VisadoRechazado { get; set; }

        public int AlertaPrescripcion { get; set; }
        public int? EstadoVisado { get; set; }

        public bool Asignable { get; set; }
        public bool Gestionable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QSiniestro, FilaSiniestroViewModel>()
                .ForMember(dest => dest.PendienteVisado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value > 0))
                .ForMember(dest => dest.VisadoRechazado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value == 0))
                .ForMember(dest => dest.AlertaPrescripcion, opt => opt.MapFrom(src => PropiedadPrescripcion.DefinirTipoAlerta(src.Prescripcion.GetValueOrDefault())));
        }
    }
}