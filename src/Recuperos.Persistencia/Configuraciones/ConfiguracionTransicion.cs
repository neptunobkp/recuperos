using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.Configuraciones
{
    public class ConfiguracionTransicion : EntityTypeConfiguration<Transicion>, IConfiguracionable
    {
        public ConfiguracionTransicion()
        {
        }
    }
}