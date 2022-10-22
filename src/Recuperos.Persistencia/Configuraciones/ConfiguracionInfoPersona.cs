using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Externo;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionInfoPersona : EntityTypeConfiguration<InfoPersona>, IConfiguracionable
    {
        public ConfiguracionInfoPersona()
        {
            Property(e => e.Nombres).HasMaxLength(200);
        }
    }
}