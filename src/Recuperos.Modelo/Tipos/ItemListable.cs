using System.ComponentModel.DataAnnotations;

namespace Recuperos.Modelo.Tipos
{
   public class ItemListable
    {
        [Key]
        public string Valor { get; set; }
        public string Texto { get; set; }
    }
}
