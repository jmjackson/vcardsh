namespace vcardsh.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InfoPagos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InfoPagoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaPago = c.DateTime(),
                        EmailCobro = c.String(),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            AddColumn("dbo.AspNetUsers", "FechaCreacion", c => c.DateTime());
            AddColumn("dbo.Perfils", "QRTelefono", c => c.String());
            AddColumn("dbo.Perfils", "QRSitioWeb", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InfoPagoes", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.InfoPagoes", new[] { "UsuarioId" });
            DropColumn("dbo.Perfils", "QRSitioWeb");
            DropColumn("dbo.Perfils", "QRTelefono");
            DropColumn("dbo.AspNetUsers", "FechaCreacion");
            DropTable("dbo.InfoPagoes");
        }
    }
}
