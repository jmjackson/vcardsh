namespace vcardsh.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetalleUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Acerca = c.String(),
                        Descripcion = c.String(),
                        OtraDescripcion = c.String(),
                        Fotografia1 = c.String(),
                        Fotografia2 = c.String(),
                        Fotografia3 = c.String(),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleUsuarios", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.DetalleUsuarios", new[] { "UsuarioId" });
            DropTable("dbo.DetalleUsuarios");
        }
    }
}
