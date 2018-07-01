namespace Controlador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostEnding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Periodoes", "Atividade_ID", "dbo.Atividades");
            DropIndex("dbo.Periodoes", new[] { "Atividade_ID" });
            RenameColumn(table: "dbo.Periodoes", name: "Atividade_ID", newName: "AtividadeID");
            AlterColumn("dbo.Periodoes", "AtividadeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Periodoes", "AtividadeID");
            AddForeignKey("dbo.Periodoes", "AtividadeID", "dbo.Atividades", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodoes", "AtividadeID", "dbo.Atividades");
            DropIndex("dbo.Periodoes", new[] { "AtividadeID" });
            AlterColumn("dbo.Periodoes", "AtividadeID", c => c.Int());
            RenameColumn(table: "dbo.Periodoes", name: "AtividadeID", newName: "Atividade_ID");
            CreateIndex("dbo.Periodoes", "Atividade_ID");
            AddForeignKey("dbo.Periodoes", "Atividade_ID", "dbo.Atividades", "ID");
        }
    }
}
