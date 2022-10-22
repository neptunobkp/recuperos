using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Externo;
using Recuperos.Modelo.Queries;

namespace Recuperos.Aplicacion.Interfaces
{
    public interface IAppDbContext : IDisposable
    {
        DbSet<SolicitudVisto> SolicitudesVisto { get; set; }
        DbSet<Etapa> Etapas { get; set; }
        DbSet<Estado> Estados { get; set; }
        DbSet<Transicion> Transiciones { get; set; }

        DbSet<Tercero> Terceros { get; set; }
        DbSet<TerceroVehiculo> VehiculosTercero { get; set; }
        DbSet<Siniestro> Siniestros { get; set; }
        DbSet<EntradaBitacora> EntradasBitacoras { get; set; }
        DbSet<EntradaObservacion> EntradasObservaciones { get; set; }
        DbSet<TipoBitacora> TiposBitacora { get; set; }
        DbSet<TipoObservacion> TiposObservacion { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<ArchivoAdjunto> Archivos { get; set; }

        DbSet<InfoVehiculo> InfoVehiculos { get; set; }
        DbSet<InfoPersona> InfoPersonas { get; set; }

        DbSet<InfoDireccion> InfoDirecciones { get; set; }
        DbSet<InfoTelefono> InfoTelefonos { get; set; }
        DbSet<InfoCorreo> InfoCorreos { get; set; }

        DbSet<Sincro> Sincros { get; set; }
        DbSet<QSiniestro> QSiniestros { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
