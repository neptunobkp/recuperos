using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionEtapa : EntityTypeConfiguration<Etapa>, IConfiguracionable
    {
        public ConfiguracionEtapa()
        {
            Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
