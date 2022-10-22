using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Externo;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionInfoTelefono : EntityTypeConfiguration<InfoTelefono>, IConfiguracionable
    {
        public ConfiguracionInfoTelefono()
        {
            ToTable("INFOTELEFONOS");
            Property(e => e.CodigoPais).HasMaxLength(200);
            Property(e => e.CodigoArea).HasMaxLength(200);
            Property(e => e.Numero).HasMaxLength(200);
        }
    }
}