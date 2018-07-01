namespace Controlador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Times", "Usuario_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Times", "Criador_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Time_ID", "dbo.Times");
            DropIndex("dbo.Times", new[] { "Usuario_ID" });
            DropIndex("dbo.Times", new[] { "Criador_ID" });
            DropIndex("dbo.Usuarios", new[] { "Time_ID" });
            AddColumn("dbo.Atividades", "Titulo", c => c.String());
            AddColumn("dbo.Atividades", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Atividades", "Completada");
            DropColumn("dbo.Usuarios", "Time_ID");
            DropTable("dbo.Times");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Criado = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Usuario_ID = c.Int(),
                        Criador_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Usuarios", "Time_ID", c => c.Int());
            AddColumn("dbo.Atividades", "Completada", c => c.DateTime(nullable: false));
            DropColumn("dbo.Atividades", "Status");
            DropColumn("dbo.Atividades", "Titulo");
            CreateIndex("dbo.Usuarios", "Time_ID");
            CreateIndex("dbo.Times", "Criador_ID");
            CreateIndex("dbo.Times", "Usuario_ID");
            AddForeignKey("dbo.Usuarios", "Time_ID", "dbo.Times", "ID");
            AddForeignKey("dbo.Times", "Criador_ID", "dbo.Usuarios", "ID");
            AddForeignKey("dbo.Times", "Usuario_ID", "dbo.Usuarios", "ID");
        }
    }
}
