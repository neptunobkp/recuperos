using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionTerceroVehiculo : EntityTypeConfiguration<TerceroVehiculo>, IConfiguracionable
    {
        public ConfiguracionTerceroVehiculo()
        {

            Property(e => e.Patente).HasMaxLength(200);
            Property(e => e.Marca).HasMaxLength(200);
            Property(e => e.Modelo).HasMaxLength(200);
            Property(e => e.Color).HasMaxLength(200);
            Property(e => e.LaVersion).HasMaxLength(200);
            Property(e => e.NumeroMotor).HasMaxLength(200);
            Property(e => e.NumeroChasis).HasMaxLength(200);
        }
    }
}