namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Ondernemingsid = c.Int(nullable: false),
                        Naam = c.String(),
                        Beschrijving = c.String(),
                        Adres = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Ondernemings", t => t.Ondernemingsid, cascadeDelete: true)
                .Index(t => t.Ondernemingsid);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Ondernemingsid", "dbo.Ondernemings");
            DropForeignKey("dbo.Vestigings", "Ondernemingid", "dbo.Ondernemings");
            DropIndex("dbo.Vestigings", new[] { "Ondernemingid" });
            DropIndex("dbo.Events", new[] { "Ondernemingsid" });
            DropTable("dbo.Vestigings");
            DropTable("dbo.Ondernemings");
            DropTable("dbo.Events");
        }
    }
}
