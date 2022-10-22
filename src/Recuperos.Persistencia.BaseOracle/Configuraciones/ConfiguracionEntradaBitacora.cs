using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionEntradaBitacora : EntityTypeConfiguration<EntradaBitacora>, IConfiguracionable
    {
        public ConfiguracionEntradaBitacora()
        {
            ToTable("ENTRADASBITACORA");
            Property(e => e.Hora).HasMaxLength(10);
            Property(e => e.Detalle).HasMaxLength(999);
        }
    }
}