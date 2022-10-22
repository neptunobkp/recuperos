using System.Data.Entity.ModelConfiguration;
using Recuperos.Modelo.Externo;

namespace Recuperos.Persistencia.BaseOracle.Configuraciones
{
    public class ConfiguracionInfoDireccion : EntityTypeConfiguration<InfoDireccion>, IConfiguracionable
    {
        public ConfiguracionInfoDireccion()
        {
            ToTable("INFODIRECCIONES");
            Property(e => e.Calle).HasMaxLength(900);
            Property(e => e.Numero).HasMaxLength(200);
            Property(e => e.Comuna).HasMaxLength(200);
            Property(e => e.Region).HasMaxLength(200);
            Property(e => e.Referencia).HasMaxLength(900);
            Property(e => e.Verificada).HasMaxLength(2);
            Property(e => e.Tipo).HasMaxLength(200);
        }
    }
}