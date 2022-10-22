using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionEntradaObservacion : EntityTypeConfiguration<EntradaObservacion>, IConfiguracionable
    {
        public ConfiguracionEntradaObservacion()
        {
            Property(e => e.Hora).HasMaxLength(10);
            Property(e => e.Detalle).HasMaxLength(999);
        }
    }
}