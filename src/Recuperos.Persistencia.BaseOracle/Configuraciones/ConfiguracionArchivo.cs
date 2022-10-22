using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionArchivo : EntityTypeConfiguration<ArchivoAdjunto>, IConfiguracionable
    {
        public ConfiguracionArchivo()
        {
            ToTable("ARCHIVOSADJUNTOS");
            Property(e => e.Nombre).HasMaxLength(200);
            Property(e => e.Extension).HasMaxLength(20);
            Property(e => e.Url).HasMaxLength(999);
        }
    }
}