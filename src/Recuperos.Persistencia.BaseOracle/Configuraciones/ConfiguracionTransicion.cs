using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionTransicion : EntityTypeConfiguration<Transicion>, IConfiguracionable
    {
        public ConfiguracionTransicion()
        {
            ToTable("TRANSICIONES");
        }
    }
}