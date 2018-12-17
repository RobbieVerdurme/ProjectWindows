namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Vestigingid = c.Int(nullable: false),
                        Naam = c.String(),
                        Beschrijving = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Vestigings", t => t.Vestigingid, cascadeDelete: true)
                .Index(t => t.Vestigingid);
            
            CreateTable(
                "dbo.Vestigings",
                c => new
                    {
                        VestigingId = c.Int(nullable: false, identity: true),
                        Ondernemingid = c.Int(nullable: false),
                        Naam = c.String(),
                        Adres = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VestigingId)
                .ForeignKey("dbo.Ondernemings", t => t.Ondernemingid, cascadeDelete: true)
                .Index(t => t.Ondernemingid);
            
            CreateTable(
                "dbo.Ondernemings",
                c => new
                    {
                        OndernemingID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Soort = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.OndernemingID);
            
            CreateTable(
                "dbo.Promoties",
                c => new
                    {
                        PromotieID = c.Int(nullable: false, identity: true),
                        OndernemingID = c.Int(nullable: false),
                        Percentage = c.Double(nullable: false),
                        Beschrijving = c.String(),
                        Van = c.DateTime(nullable: false),
                        Tot = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotieID)
                .ForeignKey("dbo.Ondernemings", t => t.OndernemingID, cascadeDelete: true)
                .Index(t => t.OndernemingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promoties", "OndernemingID", "dbo.Ondernemings");
            DropForeignKey("dbo.Events", "Vestigingid", "dbo.Vestigings");
            DropForeignKey("dbo.Vestigings", "Ondernemingid", "dbo.Ondernemings");
            DropIndex("dbo.Promoties", new[] { "OndernemingID" });
            DropIndex("dbo.Vestigings", new[] { "Ondernemingid" });
            DropIndex("dbo.Events", new[] { "Vestigingid" });
            DropTable("dbo.Promoties");
            DropTable("dbo.Ondernemings");
            DropTable("dbo.Vestigings");
            DropTable("dbo.Events");
        }
    }
}
