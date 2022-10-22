using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionEntradaObservacion : EntityTypeConfiguration<EntradaObservacion>, IConfiguracionable
    {
        public ConfiguracionEntradaObservacion()
        {
            ToTable("ENTRADASOBSERVACION");
            Property(e => e.Hora).HasMaxLength(10);
            Property(e => e.Detalle).HasMaxLength(999);
        }
    }
}