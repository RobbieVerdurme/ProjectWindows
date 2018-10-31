namespace StadsApp_Backend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StadsApp_Backend.Models.StadsApp_BackendContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StadsApp_Backend.Models.StadsApp_BackendContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Ondernemings.AddOrUpdate(x => x.OndernemingID,
                new Models.Onderneming() { OndernemingID = 1, Naam = "Test", Adres = "Bakkerstraat", Soort = "Bakker" },
                new Models.Onderneming() { OndernemingID = 1, Naam = "Koen", Adres = "Bakkerstraat", Soort = "restaurant" },
                new Models.Onderneming() { OndernemingID=1, Naam="lidle", Adres="Bakkerstraat", Soort="winkel"}
                );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
