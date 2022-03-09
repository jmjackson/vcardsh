namespace vcardsh.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPerfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Twitter = c.String(),
                        Facebook = c.String(),
                        Instagram = c.String(),
                        Web = c.String(),
                        Direccion = c.String(),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Perfils", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Perfils", new[] { "UsuarioId" });
            DropTable("dbo.Perfils");
        }
    }
}
