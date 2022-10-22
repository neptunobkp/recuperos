using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionEstado : EntityTypeConfiguration<Estado>, IConfiguracionable
    {
        public ConfiguracionEstado()
        {
            ToTable("ESTADOS");
            Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}