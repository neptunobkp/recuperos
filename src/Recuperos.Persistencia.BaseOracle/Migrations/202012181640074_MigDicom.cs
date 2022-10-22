namespace Recuperos.Persistencia.BaseOracle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigDicom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ADMSISREC.INFOCORREOS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Correo = c.String(maxLength: 500),
                        InfoPersonaId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.INFOPERSONAS", t => t.InfoPersonaId)
                .Index(t => t.InfoPersonaId);
            
            CreateTable(
                "ADMSISREC.INFODIRECCIONES",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Calle = c.String(maxLength: 900),
                        Numero = c.String(maxLength: 200),
                        Comuna = c.String(maxLength: 200),
                        Region = c.String(maxLength: 200),
                        Referencia = c.String(maxLength: 900),
                        Verificada = c.String(maxLength: 2),
                        Fecha = c.DateTime(),
                        Tipo = c.String(maxLength: 200),
                        InfoPersonaId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.INFOPERSONAS", t => t.InfoPersonaId)
                .Index(t => t.InfoPersonaId);
            
            CreateTable(
                "ADMSISREC.INFOTELEFONOS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CodigoPais = c.String(maxLength: 200),
                        CodigoArea = c.String(maxLength: 200),
                        Numero = c.String(maxLength: 200),
                        FechaVerificacion = c.DateTime(),
                        InfoPersonaId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ADMSISREC.INFOPERSONAS", t => t.InfoPersonaId)
                .Index(t => t.InfoPersonaId);
            
            AddColumn("ADMSISREC.INFOPERSONAS", "Clave", c => c.String());
            AddColumn("ADMSISREC.INFOPERSONAS", "SiniestroId", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("ADMSISREC.INFOPERSONAS", "TerceroId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("ADMSISREC.INFOPERSONAS", "SiniestroId");
            AddForeignKey("ADMSISREC.INFOPERSONAS", "SiniestroId", "ADMSISREC.SINIESTROS", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("ADMSISREC.INFOTELEFONOS", "InfoPersonaId", "ADMSISREC.INFOPERSONAS");
            DropForeignKey("ADMSISREC.INFOPERSONAS", "SiniestroId", "ADMSISREC.SINIESTROS");
            DropForeignKey("ADMSISREC.INFODIRECCIONES", "InfoPersonaId", "ADMSISREC.INFOPERSONAS");
            DropForeignKey("ADMSISREC.INFOCORREOS", "InfoPersonaId", "ADMSISREC.INFOPERSONAS");
            DropIndex("ADMSISREC.INFOTELEFONOS", new[] { "InfoPersonaId" });
            DropIndex("ADMSISREC.INFODIRECCIONES", new[] { "InfoPersonaId" });
            DropIndex("ADMSISREC.INFOPERSONAS", new[] { "SiniestroId" });
            DropIndex("ADMSISREC.INFOCORREOS", new[] { "InfoPersonaId" });
            DropColumn("ADMSISREC.INFOPERSONAS", "TerceroId");
            DropColumn("ADMSISREC.INFOPERSONAS", "SiniestroId");
            DropColumn("ADMSISREC.INFOPERSONAS", "Clave");
            DropTable("ADMSISREC.INFOTELEFONOS");
            DropTable("ADMSISREC.INFODIRECCIONES");
            DropTable("ADMSISREC.INFOCORREOS");
        }
    }
}
