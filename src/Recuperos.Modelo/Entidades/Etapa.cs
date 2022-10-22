using System.Collections.Generic;

namespace Recuperos.Modelo.Entidades
{
    public class Etapa
    {
        public Etapa()
        {
            Estados  = new List<Estado>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual List<Estado> Estados { get; set; }

        public bool Eliminado { get; set; }
    }
}
