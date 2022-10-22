using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Externo;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionInfoPersona : EntityTypeConfiguration<InfoPersona>, IConfiguracionable
    {
        public ConfiguracionInfoPersona()
        {
            ToTable("INFOPERSONAS");
            Property(e => e.Nombres).HasMaxLength(200);
            Property(e => e.Origen).HasMaxLength(200);
            Property(e => e.Direccion).HasMaxLength(600);
            Property(e => e.Correo).HasMaxLength(200);
            Property(e => e.Telefono).HasMaxLength(200);
        }
    }
}