namespace Recuperos.Persistencia.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigComplementoInfoPersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InfoPersonas", "Direccion", c => c.String());
            AddColumn("dbo.InfoPersonas", "Correo", c => c.String());
            AddColumn("dbo.InfoPersonas", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InfoPersonas", "Telefono");
            DropColumn("dbo.InfoPersonas", "Correo");
            DropColumn("dbo.InfoPersonas", "Direccion");
        }
    }
}
