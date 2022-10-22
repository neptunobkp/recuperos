namespace Recuperos.Persistencia.BaseOracle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigQSiniestros : DbMigration
    {
        public override void Up()
        {
            AddColumn("ADMSISREC.ESTADOS", "DiasInfo", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("ADMSISREC.ESTADOS", "DiasAdvertencia", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("ADMSISREC.ESTADOS", "EstrategiaCalculo", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("ADMSISREC.TERCEROS", "DireccionAlt", c => c.String(maxLength: 200));
            CreateIndex("ADMSISREC.SINIESTROS", new[] { "Numero", "Riesgo" }, unique: true, name: "IXU_Numero_Riesgo");
        }
        
        public override void Down()
        {
            DropIndex("ADMSISREC.SINIESTROS", "IXU_Numero_Riesgo");
            DropColumn("ADMSISREC.TERCEROS", "DireccionAlt");
            DropColumn("ADMSISREC.ESTADOS", "EstrategiaCalculo");
            DropColumn("ADMSISREC.ESTADOS", "DiasAdvertencia");
            DropColumn("ADMSISREC.ESTADOS", "DiasInfo");
        }
    }
}
