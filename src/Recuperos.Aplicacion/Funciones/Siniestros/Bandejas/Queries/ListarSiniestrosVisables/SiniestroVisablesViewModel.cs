using System;
using System.Linq;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables
{
    public class SiniestroVisablesViewModel : IMapFrom<Siniestro>
    {
        public SiniestroVisablesViewModel()
        {
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Riesgo { get; set; }
        public DateTime? FechaDenuncio { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        public DateTime? Prescripcion { get; set; }
        public DateTime FechaImportacion { get; set; }
        public string Probabilidad { get; set; }
        public string Compania { get; set; }
        public int? Provision { get; set; }
        public int? GastoUf { get; set; }
        public int? MontoOr { get; set; }
        public bool Aceptado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string EjecutivoNombres { get; set; }
        public int? DiasGestion { get; set; }
        public string AlertaGestion { get; set; }
        public string EstadoNombre { get; set; }
        public string NumeroPoliza { get; set; }
        public string TipoDanio { get; set; }
        public string TipoOrden { get; set; }
        public bool Alertado { get; set; }
        public int? DiasAlerta { get; set; }
        public string Region { get; set; }

        public bool PendienteVisado { get; set; }

        public string EstadoDestino { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroVisablesViewModel>()
                .ForMember(dest => dest.DiasGestion, opt => opt.MapFrom(src => (int?)(DateTime.Now - src.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays))
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => ((TiposCompania)src.Compania).ToString()))
                .ForMember(dest => dest.EstadoDestino, opt => opt.MapFrom(src => GetEstadoDestino(src)))
                .ForMember(dest => dest.PendienteVisado, opt => opt.MapFrom(src => src.EstadoVisado.HasValue))
                .ForMember(dest => dest.Probabilidad, opt => opt.MapFrom(src => ((TiposProbabilidad)src.Probabilidad).GetDescription()));

        }

        private static string GetEstadoDestino(Siniestro src)
        {
            if (src.SolicitudesVisto != null && src.SolicitudesVisto.Count > 0)
            {
                var ultimaSolicitudPendiente =
                    src.SolicitudesVisto.Where(t => t.Pendiente).OrderByDescending(t => t.Id).First();

                return ultimaSolicitudPendiente?.EstadoTDestino?.Nombre;
            }

            return string.Empty;
        }
    }
}
