using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionSiniestro : EntityTypeConfiguration<Siniestro>, IConfiguracionable
    {
        public ConfiguracionSiniestro()
        {

            Property(e => e.CodigoSucursal).HasMaxLength(1);
            Property(e => e.TipoDocumento).HasMaxLength(1);
            Property(e => e.ActualizadoPor).HasMaxLength(90);
            Property(e => e.TipoOrden).HasMaxLength(15);
            Property(e => e.TipoDanio).HasMaxLength(15);

            Property(x => x.Numero)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Numero_Riesgo", 0) { IsUnique = true }));

            Property(x => x.Riesgo)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Numero_Riesgo", 1) { IsUnique = true }));

            HasIndex(u => u.Numero);
            HasIndex(u => u.EstadoId);
            HasIndex(u => u.Compania);
            HasIndex(u => u.EjecutivoId);

        }
    }
}
