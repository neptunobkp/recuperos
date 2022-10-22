using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionTipoObservacion : EntityTypeConfiguration<TipoObservacion>, IConfiguracionable
    {
        public ConfiguracionTipoObservacion()
        {
            ToTable("TIPOSOBSERVACION");
            Property(e => e.Nombre).HasMaxLength(200);
        }
    }
}