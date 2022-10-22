using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Estados.Queries.ListarEstados
{
    public class ListarEstadosQuery : IRequest<IEnumerable<ItemLista>>
    {
        [Display(Name = "La etapa")]
        public int EtapaId { get; set; }
    }
}
