using System.Collections.Generic;
using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Commands
{
    public class GestionSiniestroCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
        public Campo EstadoId { get; set; }
        public Campo Probabilidad { get; set; }

        public CampoTexto CompaniaTercero { get; set; }
        public Campo NumeroTercero { get; set; }
        public CampoFecha FechaPromesa { get; set; }
        public Campo Monto { get; set; }
        public CampoTexto Telefono { get; set; }
        public CampoFecha FechaCarta { get; set; }
        public Campo MontoSolicitado { get; set; }
        public CampoTexto EstudioAbogados { get; set; }
    }
}