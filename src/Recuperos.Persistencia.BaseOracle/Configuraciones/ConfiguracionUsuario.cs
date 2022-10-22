using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionUsuario : EntityTypeConfiguration<Usuario>, IConfiguracionable
    {
        public ConfiguracionUsuario()
        {
            ToTable("USUARIOS");
            Property(e => e.Nombres).HasMaxLength(200);
            Property(e => e.Correo).HasMaxLength(200);
            Property(e => e.Contrasena).HasMaxLength(200);

            Property(e => e.NombreIngreso).HasMaxLength(200)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Nombre_Ingreso") { IsUnique = true }));


            Property(e => e.Rut).HasMaxLength(50);
            Property(e => e.Rol).HasMaxLength(200);
        }
    }
}