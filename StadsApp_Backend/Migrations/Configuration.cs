namespace StadsApp_Backend.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<StadsApp_Backend.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StadsApp_Backend.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Ondernemer"));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Gebruiker"));
            context.Users.AddOrUpdate(x => x.Email, new Models.ApplicationUser()
            {
                UserName = "ondernemer@gent.be",
                PasswordHash = "AHem6nPNJw0dSMoRO5gDZdRjentMSOjEZp9xKcuudIhQ+vgiA+6fVmqjY99FNXYR+g==",
                SecurityStamp = "e556582d-7e6f-4891-8c94-7f6c08d1177c",
                Email = "ondernemer@gent.be"
            }
            );
            context.Users.AddOrUpdate(x => x.Email, new Models.ApplicationUser()
            {
                UserName = "user@gent.be",
                PasswordHash = "ABgPNvTAvs0JdeyeF/YScLO/N0J5g6WaOyIYpMllcii45fl3acxTG4PhvqCvL3qI3g==",
                SecurityStamp = "9211af25-5c2d-4c56-8d80-48c8fdc3035d",
                Email = "user@gent.be"
            }
            );
            SaveChanges(context);
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
