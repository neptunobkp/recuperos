using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionEtapa : EntityTypeConfiguration<Etapa>, IConfiguracionable
    {
        public ConfiguracionEtapa()
        {
            ToTable("ETAPAS");
            Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
