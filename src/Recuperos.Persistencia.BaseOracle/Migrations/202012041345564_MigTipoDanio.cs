namespace Recuperos.Persistencia.BaseOracle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigTipoDanio : DbMigration
    {
        public override void Up()
        {
            AddColumn("ADMSISREC.SINIESTROS", "UltimoEjecutivoAsignado", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("ADMSISREC.SINIESTROS", "UltimoEjecutivoAsignado");
        }
    }
}
