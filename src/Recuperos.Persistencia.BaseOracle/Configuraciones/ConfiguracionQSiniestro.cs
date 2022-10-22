using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Queries;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionQSiniestro : EntityTypeConfiguration<QSiniestro>, IConfiguracionable
    {
        public ConfiguracionQSiniestro()
        {
            ToTable("QSINIESTROMC");
        }
    }
}
