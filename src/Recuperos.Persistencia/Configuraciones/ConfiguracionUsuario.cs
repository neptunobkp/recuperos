using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionUsuario : EntityTypeConfiguration<Usuario>, IConfiguracionable
    {
        public ConfiguracionUsuario()
        {
            Property(e => e.Nombres).HasMaxLength(200);
            Property(e => e.Correo).HasMaxLength(200);
            Property(e => e.Contrasena).HasMaxLength(200);
            Property(e => e.Rol).HasMaxLength(200);
        }
    }
}