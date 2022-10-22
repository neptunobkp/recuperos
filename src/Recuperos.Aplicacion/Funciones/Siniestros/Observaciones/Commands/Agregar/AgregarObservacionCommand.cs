using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Commands.Agregar
{
    public class AgregarObservacionCommand : IRequest, IMapFrom<EntradaObservacion>
    {
        public int SiniestroId { get; set; }
        public string Detalle { get; set; }
        public int TipoObservacionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AgregarObservacionCommand, EntradaObservacion>();
        }
    }
}
