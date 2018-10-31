namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ondernemings",
                c => new
                    {
                        OndernemingID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Adres = c.String(),
                        Soort = c.String(),
                    })
                .PrimaryKey(t => t.OndernemingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ondernemings");
        }
    }
}
