using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionEstado : EntityTypeConfiguration<Estado>, IConfiguracionable
    {
        public ConfiguracionEstado()
        {
            Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}