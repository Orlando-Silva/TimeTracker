namespace Controlador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeNome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Times", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Times", "Nome");
        }
    }
}
