namespace Recuperos.Persistencia.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntradaBitacoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiniestroId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.String(maxLength: 10),
                        TipoBitacoraId = c.Int(nullable: false),
                        Detalle = c.String(maxLength: 999),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Siniestroes", t => t.SiniestroId)
                .ForeignKey("dbo.TipoBitacoras", t => t.TipoBitacoraId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.SiniestroId)
                .Index(t => t.UsuarioId)
                .Index(t => t.TipoBitacoraId);
            
            CreateTable(
                "dbo.Siniestroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Riesgo = c.Int(nullable: false),
                        FechaDenuncio = c.DateTime(),
                        FechaSiniestro = c.DateTime(),
                        FechaAsignacion = c.DateTime(),
                        Prescripcion = c.DateTime(),
                        FechaUltimaActualizacion = c.DateTime(nullable: false),
                        FechaImportacion = c.DateTime(nullable: false),
                        Compania = c.Int(nullable: false),
                        Probabilidad = c.Int(nullable: false),
                        Provision = c.Int(),
                        GastoUf = c.Int(),
                        MontoOr = c.Int(),
                        EjecutivoId = c.Int(),
                        EstadoId = c.Int(),
                        CodigoSucursal = c.String(maxLength: 1),
                        TipoDocumento = c.String(maxLength: 1),
                        NumeroPoliza = c.Long(nullable: false),
                        NumeroItem = c.Int(nullable: false),
                        TipoDanio = c.String(maxLength: 15),
                        TipoOrden = c.String(maxLength: 15),
                        Aceptado = c.Boolean(),
                        ActualizadoPor = c.String(maxLength: 90),
                        Destacado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.EjecutivoId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => new { t.Numero, t.Riesgo }, unique: true)
                .Index(t => t.Numero)
                .Index(t => t.Compania)
                .Index(t => t.EjecutivoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 200),
                        Correo = c.String(maxLength: 200),
                        Contrasena = c.String(maxLength: 200),
                        Rol = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                        EtapaId = c.Int(nullable: false),
                        DiasAlerta = c.Int(),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etapas", t => t.EtapaId)
                .Index(t => t.EtapaId);
            
            CreateTable(
                "dbo.Etapas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transicions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstadoOrigenId = c.Int(nullable: false),
                        EstadoDestinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.EstadoDestinoId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoOrigenId)
                .Index(t => t.EstadoOrigenId)
                .Index(t => t.EstadoDestinoId);
            
            CreateTable(
                "dbo.TipoBitacoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EntradaObservacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiniestroId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.String(maxLength: 10),
                        TipoObservacionId = c.Int(nullable: false),
                        Detalle = c.String(maxLength: 999),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Siniestroes", t => t.SiniestroId)
                .ForeignKey("dbo.TipoObservacions", t => t.TipoObservacionId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.SiniestroId)
                .Index(t => t.UsuarioId)
                .Index(t => t.TipoObservacionId);
            
            CreateTable(
                "dbo.TipoObservacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InfoPersonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rut = c.Int(nullable: false),
                        Nombres = c.String(maxLength: 200),
                        FechaConsulta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InfoVehiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patente = c.String(maxLength: 200),
                        Marca = c.String(maxLength: 200),
                        Modelo = c.String(maxLength: 200),
                        Anio = c.Int(),
                        Color = c.String(maxLength: 200),
                        NumeroMotor = c.String(maxLength: 200),
                        NumeroChasis = c.String(maxLength: 200),
                        FechaConsulta = c.DateTime(nullable: false),
                        InfoPersonaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoPersonas", t => t.InfoPersonaId)
                .Index(t => t.InfoPersonaId);
            
            CreateTable(
                "dbo.Sincroes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Terceroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiniestroId = c.Int(nullable: false),
                        Nombres = c.String(maxLength: 200),
                        Rut = c.Int(nullable: false),
                        Direccion = c.String(maxLength: 200),
                        Correo = c.String(maxLength: 200),
                        CorreoAlt = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 200),
                        TelefonoAlt = c.String(maxLength: 200),
                        Alias = c.String(maxLength: 200),
                        EsPrincipal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Siniestroes", t => t.SiniestroId)
                .Index(t => t.SiniestroId);
            
            CreateTable(
                "dbo.TerceroVehiculoes",
                c => new
                    {
                        TerceroVehiculoId = c.Int(nullable: false),
                        Patente = c.String(maxLength: 200),
                        Marca = c.String(maxLength: 200),
                        Modelo = c.String(maxLength: 200),
                        Anio = c.Int(),
                        Color = c.String(maxLength: 200),
                        NumeroMotor = c.String(maxLength: 200),
                        NumeroChasis = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.TerceroVehiculoId)
                .ForeignKey("dbo.Terceroes", t => t.TerceroVehiculoId)
                .Index(t => t.TerceroVehiculoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TerceroVehiculoes", "TerceroVehiculoId", "dbo.Terceroes");
            DropForeignKey("dbo.Terceroes", "SiniestroId", "dbo.Siniestroes");
            DropForeignKey("dbo.InfoVehiculoes", "InfoPersonaId", "dbo.InfoPersonas");
            DropForeignKey("dbo.EntradaObservacions", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.EntradaObservacions", "TipoObservacionId", "dbo.TipoObservacions");
            DropForeignKey("dbo.EntradaObservacions", "SiniestroId", "dbo.Siniestroes");
            DropForeignKey("dbo.EntradaBitacoras", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.EntradaBitacoras", "TipoBitacoraId", "dbo.TipoBitacoras");
            DropForeignKey("dbo.EntradaBitacoras", "SiniestroId", "dbo.Siniestroes");
            DropForeignKey("dbo.Siniestroes", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Transicions", "EstadoOrigenId", "dbo.Estadoes");
            DropForeignKey("dbo.Transicions", "EstadoDestinoId", "dbo.Estadoes");
            DropForeignKey("dbo.Estadoes", "EtapaId", "dbo.Etapas");
            DropForeignKey("dbo.Siniestroes", "EjecutivoId", "dbo.Usuarios");
            DropIndex("dbo.TerceroVehiculoes", new[] { "TerceroVehiculoId" });
            DropIndex("dbo.Terceroes", new[] { "SiniestroId" });
            DropIndex("dbo.InfoVehiculoes", new[] { "InfoPersonaId" });
            DropIndex("dbo.EntradaObservacions", new[] { "TipoObservacionId" });
            DropIndex("dbo.EntradaObservacions", new[] { "UsuarioId" });
            DropIndex("dbo.EntradaObservacions", new[] { "SiniestroId" });
            DropIndex("dbo.Transicions", new[] { "EstadoDestinoId" });
            DropIndex("dbo.Transicions", new[] { "EstadoOrigenId" });
            DropIndex("dbo.Estadoes", new[] { "EtapaId" });
            DropIndex("dbo.Siniestroes", new[] { "EstadoId" });
            DropIndex("dbo.Siniestroes", new[] { "EjecutivoId" });
            DropIndex("dbo.Siniestroes", new[] { "Compania" });
            DropIndex("dbo.Siniestroes", new[] { "Numero" });
            DropIndex("dbo.Siniestroes", new[] { "Numero", "Riesgo" });
            DropIndex("dbo.EntradaBitacoras", new[] { "TipoBitacoraId" });
            DropIndex("dbo.EntradaBitacoras", new[] { "UsuarioId" });
            DropIndex("dbo.EntradaBitacoras", new[] { "SiniestroId" });
            DropTable("dbo.TerceroVehiculoes");
            DropTable("dbo.Terceroes");
            DropTable("dbo.Sincroes");
            DropTable("dbo.InfoVehiculoes");
            DropTable("dbo.InfoPersonas");
            DropTable("dbo.TipoObservacions");
            DropTable("dbo.EntradaObservacions");
            DropTable("dbo.TipoBitacoras");
            DropTable("dbo.Transicions");
            DropTable("dbo.Etapas");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Siniestroes");
            DropTable("dbo.EntradaBitacoras");
        }
    }
}
