using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionTipoObservacion : EntityTypeConfiguration<TipoObservacion>, IConfiguracionable
    {
        public ConfiguracionTipoObservacion()
        {
            Property(e => e.Nombre).HasMaxLength(200);
        }
    }
}