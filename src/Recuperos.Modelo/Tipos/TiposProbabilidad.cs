using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recuperos.Modelo.Tipos
{
    public enum TiposProbabilidad
    {
        [Display( Name = "")]
        [Description("")]
        Indefinida,

        [Display(Name = "Baja")]
        [Description("Baja")]
        Baja,
        Media,
        Alta,
    }
}
