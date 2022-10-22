namespace Recuperos.Persistencia.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigCompaniaInt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Siniestroes", "CompaniaTercero", c => c.String());
            AddColumn("dbo.Siniestroes", "Region", c => c.Int());
            AddColumn("dbo.Siniestroes", "NumeroTercero", c => c.Int());
            AddColumn("dbo.Usuarios", "NombreIngreso", c => c.String());
            AddColumn("dbo.InfoPersonas", "Origen", c => c.String());
            AddColumn("dbo.InfoVehiculoes", "Origen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InfoVehiculoes", "Origen");
            DropColumn("dbo.InfoPersonas", "Origen");
            DropColumn("dbo.Usuarios", "NombreIngreso");
            DropColumn("dbo.Siniestroes", "NumeroTercero");
            DropColumn("dbo.Siniestroes", "Region");
            DropColumn("dbo.Siniestroes", "CompaniaTercero");
        }
    }
}
