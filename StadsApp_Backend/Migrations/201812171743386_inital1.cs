namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital1 : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Promoties", new[] { "OndernemingID" });
            DropTable("dbo.Promoties");
        }
    }
}
