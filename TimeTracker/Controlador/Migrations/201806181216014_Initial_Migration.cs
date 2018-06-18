namespace Controlador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Atividades", t => t.Atividade_ID)
                .ForeignKey("dbo.Times", t => t.Time_ID)
                .Index(t => t.Atividade_ID)
                .Index(t => t.Time_ID);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Membroes", "Time_ID", "dbo.Times");
            DropForeignKey("dbo.Membroes", "Atividade_ID", "dbo.Atividades");
            DropIndex("dbo.Membroes", new[] { "Time_ID" });
            DropIndex("dbo.Membroes", new[] { "Atividade_ID" });
            DropTable("dbo.Times");
            DropTable("dbo.Membroes");
            DropTable("dbo.Atividades");
        }
    }
}
