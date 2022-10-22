using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionTipoBitacora : EntityTypeConfiguration<TipoBitacora>, IConfiguracionable
    {
        public ConfiguracionTipoBitacora()
        {
            Property(e => e.Nombre).HasMaxLength(200);
        }
    }
}