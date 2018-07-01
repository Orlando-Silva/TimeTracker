namespace Controlador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morechanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Atividades", "Usuario_ID", "dbo.Usuarios");
            DropIndex("dbo.Atividades", new[] { "Usuario_ID" });
            RenameColumn(table: "dbo.Atividades", name: "Usuario_ID", newName: "UsuarioID");
            AlterColumn("dbo.Atividades", "UsuarioID", c => c.Int(nullable: false));
            CreateIndex("dbo.Atividades", "UsuarioID");
            AddForeignKey("dbo.Atividades", "UsuarioID", "dbo.Usuarios", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atividades", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Atividades", new[] { "UsuarioID" });
            AlterColumn("dbo.Atividades", "UsuarioID", c => c.Int());
            RenameColumn(table: "dbo.Atividades", name: "UsuarioID", newName: "Usuario_ID");
            CreateIndex("dbo.Atividades", "Usuario_ID");
            AddForeignKey("dbo.Atividades", "Usuario_ID", "dbo.Usuarios", "ID");
        }
    }
}
