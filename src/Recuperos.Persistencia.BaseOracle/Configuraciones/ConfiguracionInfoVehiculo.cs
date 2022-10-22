using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Externo;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionInfoVehiculo : EntityTypeConfiguration<InfoVehiculo>, IConfiguracionable
    {
        public ConfiguracionInfoVehiculo()
        {
            ToTable("INFOVEHICULOS");
            Property(e => e.Patente).HasMaxLength(200);
            Property(e => e.Marca).HasMaxLength(200);
            Property(e => e.Modelo).HasMaxLength(200);
            Property(e => e.Color).HasMaxLength(200);
            Property(e => e.LaVersion).HasMaxLength(200);
            Property(e => e.NumeroMotor).HasMaxLength(200);
            Property(e => e.NumeroChasis).HasMaxLength(200);
            Property(e => e.Origen).HasMaxLength(200);
        }
    }
}