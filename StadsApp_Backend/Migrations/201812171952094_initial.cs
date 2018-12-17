namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Adres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Adres", c => c.String());
        }
    }
}
