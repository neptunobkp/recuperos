using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recuperos.Modelo.Entidades
{
    public class Estado
    {
        public Estado()
        {
            TransicionesDestino = new List<Transicion>();
            TransicionesOrigen = new List<Transicion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EtapaId { get; set; }
        public virtual Etapa Etapa { get; set; }

        public int? DiasAlerta { get; set; }
        public int? DiasInfo { get; set; }
        public int? DiasAdvertencia { get; set; }
        public int? EstrategiaCalculo { get; set; }

        [InverseProperty("EstadoDestino")]
        public  ICollection<Transicion> TransicionesDestino { get; set; }

        [InverseProperty("EstadoOrigen")]
        public ICollection<Transicion> TransicionesOrigen { get; set; }


        public bool Eliminado { get; set; }
    }
}
