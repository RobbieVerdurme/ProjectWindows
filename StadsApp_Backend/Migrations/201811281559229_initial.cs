namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vestigings",
                c => new
                    {
                        VestigingId = c.Int(nullable: false, identity: true),
                        Ondernemingid = c.Int(nullable: false),
                        Naam = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.VestigingId)
                .ForeignKey("dbo.Ondernemings", t => t.Ondernemingid, cascadeDelete: true)
                .Index(t => t.Ondernemingid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vestigings", "Ondernemingid", "dbo.Ondernemings");
            DropIndex("dbo.Vestigings", new[] { "Ondernemingid" });
            DropTable("dbo.Vestigings");
        }
    }
}