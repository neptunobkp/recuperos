using System;
using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Listar
{
    public class ArchivoAdjuntoViewModel : IMapFrom<ArchivoAdjunto>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioNombres { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ArchivoAdjunto, ArchivoAdjuntoViewModel>();
        }
    }
}