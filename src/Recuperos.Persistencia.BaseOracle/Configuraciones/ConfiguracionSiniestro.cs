using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionSiniestro : EntityTypeConfiguration<Siniestro>, IConfiguracionable
    {
        public ConfiguracionSiniestro()
        {
            ToTable("SINIESTROS");

            Property(e => e.CodigoSucursal).HasMaxLength(1);
            Property(e => e.TipoDocumento).HasMaxLength(1);
            Property(e => e.ActualizadoPor).HasMaxLength(90);
            Property(e => e.TipoOrden).HasMaxLength(15);
            Property(e => e.TipoDanio).HasMaxLength(15);
            Property(e => e.CompaniaTercero).HasMaxLength(100);
            Property(e => e.Ramo).HasMaxLength(100);
            Property(e => e.Telefono).HasMaxLength(100);
            Property(e => e.EstudioAbogados).HasMaxLength(100);
            Property(e => e.UltimoEjecutivoAsignado).HasMaxLength(200);
            Property(e => e.Daterc).HasMaxLength(200);

            Property(x => x.Numero)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IXU_Numero_Riesgo", 0) { IsUnique = true }));

            Property(x => x.Riesgo)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IXU_Numero_Riesgo", 1) { IsUnique = true }));

            HasIndex(u => u.Numero);
            HasIndex(u => u.EstadoId);
            HasIndex(u => u.Compania);
            HasIndex(u => u.EjecutivoId);
        }
    }
}
