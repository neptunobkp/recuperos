using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Cabecera.Queries
{
    public class SiniestroCabeceraViewModel : IMapFrom<Siniestro>
    {
        public string Numero { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Siniestro, SiniestroCabeceraViewModel>();
        }
    }
}