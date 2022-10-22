using System.Data.Common;
using System.Data.Entity;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;
using Recuperos.Modelo.Queries;
using Recuperos.Persistencia.BaseOracle.Configuraciones;

namespace Recuperos.Persistencia.BaseOracle
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext() : base("name=RecuperosOraContext")
        {
            Database.Log = DebuggerWritter.Mensajear;
        }

        public AppDbContext(DbConnection connection) : base(connection, false)
        {
        }

        public virtual DbSet<TerceroVehiculo> VehiculosTercero { get; set; }
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<SolicitudVisto> SolicitudesVisto { get; set; }
        public virtual DbSet<Transicion> Transiciones { get; set; }
        public virtual DbSet<Siniestro> Siniestros { get; set; }
        public virtual DbSet<EntradaBitacora> EntradasBitacoras { get; set; }
        public virtual DbSet<EntradaObservacion> EntradasObservaciones { get; set; }
        public virtual DbSet<TipoBitacora> TiposBitacora { get; set; }
        public virtual DbSet<TipoObservacion> TiposObservacion { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Tercero> Terceros { get; set; }
        public virtual DbSet<InfoVehiculo> InfoVehiculos { get; set; }
        public virtual DbSet<InfoPersona> InfoPersonas { get; set; }
        public virtual DbSet<Sincro> Sincros { get; set; }
        public virtual DbSet<ArchivoAdjunto> Archivos { get; set; }

        public virtual DbSet<QSiniestro> QSiniestros { get; set; }

        public virtual DbSet<InfoDireccion> InfoDirecciones { get; set; }
        public virtual DbSet<InfoTelefono> InfoTelefonos { get; set; }
        public virtual DbSet<InfoCorreo> InfoCorreos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ADMSISREC");
            modelBuilder.ApplyAllConfigurations(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
