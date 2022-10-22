using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionSolicitudVisto : EntityTypeConfiguration<SolicitudVisto>, IConfiguracionable
    {
        public ConfiguracionSolicitudVisto()
        {
            ToTable("SOLICITUDESVISTO");
            Property(e => e.Detalle).HasMaxLength(1000);
        }
    }
}