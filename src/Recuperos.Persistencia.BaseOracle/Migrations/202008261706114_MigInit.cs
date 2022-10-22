namespace Recuperos.Persistencia.BaseOracle.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ADMSISREC.ARCHIVOSADJUNTOS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SiniestroId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Nombre = c.String(maxLength: 200),
                        Extension = c.String(maxLength: 20),
                        Url = c.String(maxLength: 999),
                        Eliminado = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.SINIESTROS", t => t.SiniestroId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.USUARIOS", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.SiniestroId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "ADMSISREC.SINIESTROS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Numero = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Riesgo = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FechaDenuncio = c.DateTime(),
                        FechaSiniestro = c.DateTime(),
                        FechaAsignacion = c.DateTime(),
                        Prescripcion = c.DateTime(),
                        FechaUltimaActualizacion = c.DateTime(nullable: false),
                        FechaImportacion = c.DateTime(nullable: false),
                        FechaUltimoCambioEstado = c.DateTime(),
                        FechaUltimoCambioEtapa = c.DateTime(),
                        FechaRecupero = c.DateTime(),
                        Ramo = c.String(maxLength: 100),
                        Compania = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Probabilidad = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Provision = c.Decimal(precision: 18, scale: 2),
                        GastoUf = c.Decimal(precision: 18, scale: 2),
                        MontoOr = c.Decimal(precision: 10, scale: 0),
                        EjecutivoId = c.Decimal(precision: 10, scale: 0),
                        EstadoId = c.Decimal(precision: 10, scale: 0),
                        CodigoSucursal = c.String(maxLength: 1),
                        TipoDocumento = c.String(maxLength: 1),
                        NumeroPoliza = c.Decimal(nullable: false, precision: 19, scale: 0),
                        NumeroItem = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TipoDanio = c.String(maxLength: 15),
                        TipoOrden = c.String(maxLength: 15),
                        Aceptado = c.Decimal(precision: 1, scale: 0),
                        ActualizadoPor = c.String(maxLength: 90),
                        Destacado = c.Decimal(nullable: false, precision: 1, scale: 0),
                        EstadoVisado = c.Decimal(precision: 10, scale: 0),
                        CompaniaTercero = c.String(maxLength: 100),
                        Region = c.Decimal(precision: 10, scale: 0),
                        NumeroTercero = c.Decimal(precision: 10, scale: 0),
                        FechaPromesa = c.DateTime(),
                        Monto = c.Decimal(precision: 10, scale: 0),
                        Telefono = c.String(maxLength: 100),
                        FechaCarta = c.DateTime(),
                        MontoSolicitado = c.Decimal(precision: 10, scale: 0),
                        EstudioAbogados = c.String(maxLength: 100),
                        Daterc = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.USUARIOS", t => t.EjecutivoId)
                .ForeignKey("ADMSISREC.ESTADOS", t => t.EstadoId)
                .Index(t => t.Numero)
                .Index(t => t.Compania)
                .Index(t => t.EjecutivoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "ADMSISREC.USUARIOS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombres = c.String(maxLength: 200),
                        NombreIngreso = c.String(nullable: false, maxLength: 200),
                        Correo = c.String(maxLength: 200),
                        Contrasena = c.String(maxLength: 200),
                        Rol = c.String(maxLength: 200),
                        Rut = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NombreIngreso, unique: true, name: "IX_Nombre_Ingreso");
            
            CreateTable(
                "ADMSISREC.SOLICITUDESVISTO",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FechaSolicitud = c.DateTime(nullable: false),
                        EstadoTOrigenId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        EstadoTDestinoId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Pendiente = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Aprobado = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SiniestroId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Detalle = c.String(maxLength: 1000),
                        FechaVisado = c.DateTime(),
                        SolicitanteId = c.Decimal(precision: 10, scale: 0),
                        VisadorId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.ESTADOS", t => t.EstadoTDestinoId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.ESTADOS", t => t.EstadoTOrigenId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.SINIESTROS", t => t.SiniestroId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.USUARIOS", t => t.SolicitanteId)
                .ForeignKey("ADMSISREC.USUARIOS", t => t.VisadorId)
                .Index(t => t.EstadoTOrigenId)
                .Index(t => t.EstadoTDestinoId)
                .Index(t => t.SiniestroId)
                .Index(t => t.SolicitanteId)
                .Index(t => t.VisadorId);
            
            CreateTable(
                "ADMSISREC.ESTADOS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 100),
                        EtapaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DiasAlerta = c.Decimal(precision: 10, scale: 0),
                        Eliminado = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.ETAPAS", t => t.EtapaId, cascadeDelete: true)
                .Index(t => t.EtapaId);
            
            CreateTable(
                "ADMSISREC.ETAPAS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 100),
                        Eliminado = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ADMSISREC.TRANSICIONES",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        EstadoOrigenId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        EstadoDestinoId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Aprobable = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.ESTADOS", t => t.EstadoDestinoId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.ESTADOS", t => t.EstadoOrigenId, cascadeDelete: true)
                .Index(t => t.EstadoOrigenId)
                .Index(t => t.EstadoDestinoId);
            
            CreateTable(
                "ADMSISREC.ENTRADASBITACORA",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SiniestroId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UsuarioId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.String(maxLength: 10),
                        TipoBitacoraId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Detalle = c.String(maxLength: 999),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.SINIESTROS", t => t.SiniestroId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.TIPOSBITACORA", t => t.TipoBitacoraId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.USUARIOS", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.SiniestroId)
                .Index(t => t.UsuarioId)
                .Index(t => t.TipoBitacoraId);
            
            CreateTable(
                "ADMSISREC.TIPOSBITACORA",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Eliminado = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ADMSISREC.ENTRADASOBSERVACION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SiniestroId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UsuarioId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.String(maxLength: 10),
                        TipoObservacionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Detalle = c.String(maxLength: 999),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.SINIESTROS", t => t.SiniestroId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.TIPOSOBSERVACION", t => t.TipoObservacionId, cascadeDelete: true)
                .ForeignKey("ADMSISREC.USUARIOS", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.SiniestroId)
                .Index(t => t.UsuarioId)
                .Index(t => t.TipoObservacionId);
            
            CreateTable(
                "ADMSISREC.TIPOSOBSERVACION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Eliminado = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ADMSISREC.INFOPERSONAS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Rut = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Nombres = c.String(maxLength: 200),
                        Direccion = c.String(maxLength: 600),
                        Correo = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 200),
                        Origen = c.String(maxLength: 200),
                        FechaConsulta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ADMSISREC.INFOVEHICULOS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Patente = c.String(maxLength: 200),
                        Marca = c.String(maxLength: 200),
                        Modelo = c.String(maxLength: 200),
                        LaVersion = c.String(maxLength: 200),
                        Anio = c.Decimal(precision: 10, scale: 0),
                        Color = c.String(maxLength: 200),
                        NumeroMotor = c.String(maxLength: 200),
                        NumeroChasis = c.String(maxLength: 200),
                        FechaConsulta = c.DateTime(nullable: false),
                        Origen = c.String(maxLength: 200),
                        InfoPersonaId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.INFOPERSONAS", t => t.InfoPersonaId)
                .Index(t => t.InfoPersonaId);
            
            CreateTable(
                "ADMSISREC.SINCROS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ADMSISREC.TERCEROS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SiniestroId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Nombres = c.String(maxLength: 200),
                        Rut = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Direccion = c.String(maxLength: 200),
                        Correo = c.String(maxLength: 200),
                        CorreoAlt = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 200),
                        TelefonoAlt = c.String(maxLength: 200),
                        Alias = c.String(maxLength: 200),
                        Clasificacion = c.Decimal(precision: 10, scale: 0),
                        Culpabilidad = c.Decimal(precision: 10, scale: 0),
                        EsPrincipal = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.SINIESTROS", t => t.SiniestroId, cascadeDelete: true)
                .Index(t => t.SiniestroId);
            
            CreateTable(
                "ADMSISREC.TERCEROVEHICULOS",
                c => new
                    {
                        TerceroVehiculoId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Patente = c.String(maxLength: 200),
                        Marca = c.String(maxLength: 200),
                        Modelo = c.String(maxLength: 200),
                        LaVersion = c.String(),
                        Anio = c.Decimal(precision: 10, scale: 0),
                        Color = c.String(maxLength: 200),
                        NumeroMotor = c.String(maxLength: 200),
                        NumeroChasis = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.TerceroVehiculoId)
                .ForeignKey("ADMSISREC.TERCEROS", t => t.TerceroVehiculoId)
                .Index(t => t.TerceroVehiculoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ADMSISREC.TERCEROVEHICULOS", "TerceroVehiculoId", "ADMSISREC.TERCEROS");
            DropForeignKey("ADMSISREC.TERCEROS", "SiniestroId", "ADMSISREC.SINIESTROS");
            DropForeignKey("ADMSISREC.INFOVEHICULOS", "InfoPersonaId", "ADMSISREC.INFOPERSONAS");
            DropForeignKey("ADMSISREC.ENTRADASOBSERVACION", "UsuarioId", "ADMSISREC.USUARIOS");
            DropForeignKey("ADMSISREC.ENTRADASOBSERVACION", "TipoObservacionId", "ADMSISREC.TIPOSOBSERVACION");
            DropForeignKey("ADMSISREC.ENTRADASOBSERVACION", "SiniestroId", "ADMSISREC.SINIESTROS");
            DropForeignKey("ADMSISREC.ENTRADASBITACORA", "UsuarioId", "ADMSISREC.USUARIOS");
            DropForeignKey("ADMSISREC.ENTRADASBITACORA", "TipoBitacoraId", "ADMSISREC.TIPOSBITACORA");
            DropForeignKey("ADMSISREC.ENTRADASBITACORA", "SiniestroId", "ADMSISREC.SINIESTROS");
            DropForeignKey("ADMSISREC.ARCHIVOSADJUNTOS", "UsuarioId", "ADMSISREC.USUARIOS");
            DropForeignKey("ADMSISREC.SINIESTROS", "EstadoId", "ADMSISREC.ESTADOS");
            DropForeignKey("ADMSISREC.SINIESTROS", "EjecutivoId", "ADMSISREC.USUARIOS");
            DropForeignKey("ADMSISREC.SOLICITUDESVISTO", "VisadorId", "ADMSISREC.USUARIOS");
            DropForeignKey("ADMSISREC.SOLICITUDESVISTO", "SolicitanteId", "ADMSISREC.USUARIOS");
            DropForeignKey("ADMSISREC.SOLICITUDESVISTO", "SiniestroId", "ADMSISREC.SINIESTROS");
            DropForeignKey("ADMSISREC.SOLICITUDESVISTO", "EstadoTOrigenId", "ADMSISREC.ESTADOS");
            DropForeignKey("ADMSISREC.SOLICITUDESVISTO", "EstadoTDestinoId", "ADMSISREC.ESTADOS");
            DropForeignKey("ADMSISREC.TRANSICIONES", "EstadoOrigenId", "ADMSISREC.ESTADOS");
            DropForeignKey("ADMSISREC.TRANSICIONES", "EstadoDestinoId", "ADMSISREC.ESTADOS");
            DropForeignKey("ADMSISREC.ESTADOS", "EtapaId", "ADMSISREC.ETAPAS");
            DropForeignKey("ADMSISREC.ARCHIVOSADJUNTOS", "SiniestroId", "ADMSISREC.SINIESTROS");
            DropIndex("ADMSISREC.TERCEROVEHICULOS", new[] { "TerceroVehiculoId" });
            DropIndex("ADMSISREC.TERCEROS", new[] { "SiniestroId" });
            DropIndex("ADMSISREC.INFOVEHICULOS", new[] { "InfoPersonaId" });
            DropIndex("ADMSISREC.ENTRADASOBSERVACION", new[] { "TipoObservacionId" });
            DropIndex("ADMSISREC.ENTRADASOBSERVACION", new[] { "UsuarioId" });
            DropIndex("ADMSISREC.ENTRADASOBSERVACION", new[] { "SiniestroId" });
            DropIndex("ADMSISREC.ENTRADASBITACORA", new[] { "TipoBitacoraId" });
            DropIndex("ADMSISREC.ENTRADASBITACORA", new[] { "UsuarioId" });
            DropIndex("ADMSISREC.ENTRADASBITACORA", new[] { "SiniestroId" });
            DropIndex("ADMSISREC.TRANSICIONES", new[] { "EstadoDestinoId" });
            DropIndex("ADMSISREC.TRANSICIONES", new[] { "EstadoOrigenId" });
            DropIndex("ADMSISREC.ESTADOS", new[] { "EtapaId" });
            DropIndex("ADMSISREC.SOLICITUDESVISTO", new[] { "VisadorId" });
            DropIndex("ADMSISREC.SOLICITUDESVISTO", new[] { "SolicitanteId" });
            DropIndex("ADMSISREC.SOLICITUDESVISTO", new[] { "SiniestroId" });
            DropIndex("ADMSISREC.SOLICITUDESVISTO", new[] { "EstadoTDestinoId" });
            DropIndex("ADMSISREC.SOLICITUDESVISTO", new[] { "EstadoTOrigenId" });
            DropIndex("ADMSISREC.USUARIOS", "IX_Nombre_Ingreso");
            DropIndex("ADMSISREC.SINIESTROS", new[] { "EstadoId" });
            DropIndex("ADMSISREC.SINIESTROS", new[] { "EjecutivoId" });
            DropIndex("ADMSISREC.SINIESTROS", new[] { "Compania" });
            DropIndex("ADMSISREC.SINIESTROS", new[] { "Numero" });
            DropIndex("ADMSISREC.ARCHIVOSADJUNTOS", new[] { "UsuarioId" });
            DropIndex("ADMSISREC.ARCHIVOSADJUNTOS", new[] { "SiniestroId" });
            DropTable("ADMSISREC.TERCEROVEHICULOS");
            DropTable("ADMSISREC.TERCEROS");
            DropTable("ADMSISREC.SINCROS");
            DropTable("ADMSISREC.INFOVEHICULOS");
            DropTable("ADMSISREC.INFOPERSONAS");
            DropTable("ADMSISREC.TIPOSOBSERVACION");
            DropTable("ADMSISREC.ENTRADASOBSERVACION");
            DropTable("ADMSISREC.TIPOSBITACORA");
            DropTable("ADMSISREC.ENTRADASBITACORA");
            DropTable("ADMSISREC.TRANSICIONES");
            DropTable("ADMSISREC.ETAPAS");
            DropTable("ADMSISREC.ESTADOS");
            DropTable("ADMSISREC.SOLICITUDESVISTO");
            DropTable("ADMSISREC.USUARIOS");
            DropTable("ADMSISREC.SINIESTROS");
            DropTable("ADMSISREC.ARCHIVOSADJUNTOS");
        }
    }
}
