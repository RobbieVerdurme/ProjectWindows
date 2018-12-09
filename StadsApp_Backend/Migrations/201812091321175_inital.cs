namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vestigings", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Vestigings", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vestigings", "Longitude");
            DropColumn("dbo.Vestigings", "Latitude");
        }
    }
}
