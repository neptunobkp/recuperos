using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionTercero : EntityTypeConfiguration<Tercero>, IConfiguracionable
    {
        public ConfiguracionTercero()
        {
            ToTable("TERCEROS");
            Property(e => e.Nombres).HasMaxLength(200);
            Property(e => e.Direccion).HasMaxLength(200);
            Property(e => e.DireccionAlt).HasMaxLength(200);
            Property(e => e.Correo).HasMaxLength(200);
            Property(e => e.CorreoAlt).HasMaxLength(200);
            Property(e => e.Telefono).HasMaxLength(200);
            Property(e => e.TelefonoAlt).HasMaxLength(200);
            Property(e => e.Alias).HasMaxLength(200);
        }
    }
}