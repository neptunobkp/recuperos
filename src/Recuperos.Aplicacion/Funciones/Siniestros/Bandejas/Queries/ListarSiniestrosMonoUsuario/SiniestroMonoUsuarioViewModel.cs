﻿using System;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMonoUsuario
{
    public class SiniestroMonoUsuarioViewModel : IMapFrom<Siniestro>
    {

        public int Id { get; set; }
        public DateTime? FechaDenuncio { get; set; }
        public DateTime? FechaSiniestro { get; set; }

        public string Probabilidad { get; set; }

        public string Compania { get; set; }
        public int Numero { get; set; }

        public decimal? Provision { get; set; }
        public decimal? GastoUf { get; set; }
        public int? MontoOr { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? Prescripcion { get; set; }


        public string EjecutivoNombres { get; set; }

        public string EjecutivoId { get; set; }
        public int? DiasGestion { get; set; }
        public int? DiasAlerta { get; set; }
        public string AlertaGestion { get; set; }
        public string EstadoNombre { get; set; }

        public string NumeroPoliza { get; set; }
        public string ActualizadoPor { get; set; }
        public bool Asignable { get; set; }
        public bool Gestionable { get; set; }
        public string Region { get; set; }
        public bool Alertado { get; set; }
        public string TipoDanio { get; set; }
        public bool Aceptado { get; set; }
        public bool PendienteVisado { get; set; }
        public bool VisadoRechazado { get; set; }

        public int DiasPrescripcion { get; set; }
        public int AlertaPrescripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroMonoUsuarioViewModel>()
                .ForMember(dest => dest.DiasGestion, opt => opt.MapFrom(src => (int?)(DateTime.Now - src.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays))
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => ((TiposCompania)src.Compania).ToString()))
                .ForMember(dest => dest.PendienteVisado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value > 0))
                .ForMember(dest => dest.VisadoRechazado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue && src.EstadoVisado.Value == 0))
                .ForMember(dest => dest.Probabilidad, opt => opt.MapFrom(src => ((TiposProbabilidad)src.Probabilidad).GetDescription()))
                .ForMember(dest => dest.AlertaPrescripcion, opt => opt.MapFrom(src => CalculoAlertaPrescripcion(src)))
                .ForMember(dest => dest.DiasPrescripcion, opt => opt.MapFrom(src => CalculoDiasPrescripcion(src)));
        }
        private int CalculoAlertaPrescripcion(Siniestro src)
        {
            if ((DateTime.Now.Date - src.FechaSiniestro.GetValueOrDefault().Date).TotalDays >= 700)
                return 2;
            if ((DateTime.Now.Date - src.FechaSiniestro.GetValueOrDefault().Date).TotalDays >= 680)
                return 1;
            return 0;
        }

        private int CalculoDiasPrescripcion(Siniestro src)
        {
            return (int)(DateTime.Now.Date - src.FechaSiniestro.GetValueOrDefault().Date).TotalDays;
        }

    }
}
