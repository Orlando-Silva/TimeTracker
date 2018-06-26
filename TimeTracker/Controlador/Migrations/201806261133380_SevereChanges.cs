namespace Controlador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SevereChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Membroes", "Atividade_ID", "dbo.Atividades");
            DropForeignKey("dbo.Membroes", "Time_ID", "dbo.Times");
            DropIndex("dbo.Membroes", new[] { "Atividade_ID" });
            DropIndex("dbo.Membroes", new[] { "Time_ID" });
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                        Atividade_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Atividades", t => t.Atividade_ID)
                .Index(t => t.Atividade_ID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Criado = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Time_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Times", t => t.Time_ID)
                .Index(t => t.Time_ID);
            
            AddColumn("dbo.Atividades", "Descricao", c => c.String());
            AddColumn("dbo.Atividades", "Criada", c => c.DateTime(nullable: false));
            AddColumn("dbo.Atividades", "Completada", c => c.DateTime(nullable: false));
            AddColumn("dbo.Atividades", "Usuario_ID", c => c.Int());
            AddColumn("dbo.Times", "Criado", c => c.DateTime(nullable: false));
            AddColumn("dbo.Times", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Times", "Usuario_ID", c => c.Int());
            AddColumn("dbo.Times", "Criador_ID", c => c.Int());
            CreateIndex("dbo.Atividades", "Usuario_ID");
            CreateIndex("dbo.Times", "Usuario_ID");
            CreateIndex("dbo.Times", "Criador_ID");
            AddForeignKey("dbo.Atividades", "Usuario_ID", "dbo.Usuarios", "ID");
            AddForeignKey("dbo.Times", "Usuario_ID", "dbo.Usuarios", "ID");
            AddForeignKey("dbo.Times", "Criador_ID", "dbo.Usuarios", "ID");
            DropColumn("dbo.Atividades", "Inicio");
            DropColumn("dbo.Atividades", "Fim");
            DropTable("dbo.Membroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Membroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Status = c.Int(nullable: false),
                        Atividade_ID = c.Int(),
                        Time_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Atividades", "Fim", c => c.DateTime(nullable: false));
            AddColumn("dbo.Atividades", "Inicio", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Usuarios", "Time_ID", "dbo.Times");
            DropForeignKey("dbo.Times", "Criador_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Times", "Usuario_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Atividades", "Usuario_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Periodoes", "Atividade_ID", "dbo.Atividades");
            DropIndex("dbo.Usuarios", new[] { "Time_ID" });
            DropIndex("dbo.Times", new[] { "Criador_ID" });
            DropIndex("dbo.Times", new[] { "Usuario_ID" });
            DropIndex("dbo.Periodoes", new[] { "Atividade_ID" });
            DropIndex("dbo.Atividades", new[] { "Usuario_ID" });
            DropColumn("dbo.Times", "Criador_ID");
            DropColumn("dbo.Times", "Usuario_ID");
            DropColumn("dbo.Times", "Status");
            DropColumn("dbo.Times", "Criado");
            DropColumn("dbo.Atividades", "Usuario_ID");
            DropColumn("dbo.Atividades", "Completada");
            DropColumn("dbo.Atividades", "Criada");
            DropColumn("dbo.Atividades", "Descricao");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Periodoes");
            CreateIndex("dbo.Membroes", "Time_ID");
            CreateIndex("dbo.Membroes", "Atividade_ID");
            AddForeignKey("dbo.Membroes", "Time_ID", "dbo.Times", "ID");
            AddForeignKey("dbo.Membroes", "Atividade_ID", "dbo.Atividades", "ID");
        }
    }
}
