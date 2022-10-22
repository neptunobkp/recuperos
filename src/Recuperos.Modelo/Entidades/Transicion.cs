using System.ComponentModel.DataAnnotations.Schema;

namespace Recuperos.Modelo.Entidades
{
    public class Transicion
    {
        public int Id { get; set; }

        [ForeignKey("EstadoOrigen")]
        public int EstadoOrigenId { get; set; }

        public  Estado EstadoOrigen { get; set; }

        [ForeignKey("EstadoDestino")]
        public int EstadoDestinoId { get; set; }
        public  Estado EstadoDestino { get; set; }
        public bool? Aprobable { get; set; }

    }
}
