namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vestigings", "Latitude");
            DropColumn("dbo.Vestigings", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vestigings", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Vestigings", "Latitude", c => c.Double(nullable: false));
        }
    }
}
