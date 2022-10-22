using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionSincro : EntityTypeConfiguration<Sincro>, IConfiguracionable
    {
        public ConfiguracionSincro()
        {
            ToTable("SINCROS");
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}