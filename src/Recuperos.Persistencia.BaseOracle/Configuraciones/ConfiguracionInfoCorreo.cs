using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Externo;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionInfoCorreo : EntityTypeConfiguration<InfoCorreo>, IConfiguracionable
    {
        public ConfiguracionInfoCorreo()
        {
            ToTable("INFOCORREOS");
            Property(e => e.Correo).HasMaxLength(500);
        }
    }
}