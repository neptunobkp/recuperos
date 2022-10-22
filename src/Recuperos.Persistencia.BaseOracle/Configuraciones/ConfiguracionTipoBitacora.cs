using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionTipoBitacora : EntityTypeConfiguration<TipoBitacora>, IConfiguracionable
    {
        public ConfiguracionTipoBitacora()
        {
            ToTable("TIPOSBITACORA");
            Property(e => e.Nombre).HasMaxLength(200);
        }
    }
}