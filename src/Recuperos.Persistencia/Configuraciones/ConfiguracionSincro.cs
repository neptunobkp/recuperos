using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionSincro : EntityTypeConfiguration<Sincro>, IConfiguracionable
    {
        public ConfiguracionSincro()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}