using System.Linq;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EleganzApi.Core
{
    public class Configuration : DbMigrationsConfiguration<EleganzContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        // Bootstrap initial values
        protected override void Seed(EleganzContext context)
        {
            // Set up user roles
            string adminRoleId;
            string userRoleId;
            if (!context.Roles.Any())
            {
                adminRoleId = context.Roles.Add(new IdentityRole("Admin")).Id;
                userRoleId = context.Roles.Add(new IdentityRole("User")).Id;
            }
            else
            {
                adminRoleId = context.Roles.First(r => "Admin".Equals(r.Name)).Id;
                userRoleId = context.Roles.First(r => "User".Equals(r.Name)).Id;
            }
            context.SaveChanges();

            if (!context.Users.Any())
            {
                var admin = context.Users.Add(new IdentityUser("admin") { Email = "admin@eleganz.com", EmailConfirmed = true });
                admin.Roles.Add(new IdentityUserRole { RoleId = adminRoleId });

                var user = context.Users.Add(new IdentityUser("user") { Email = "user@eleganz.com", EmailConfirmed = true });
                user.Roles.Add(new IdentityUserRole { RoleId = userRoleId });

                context.SaveChanges();

                var store = new EleganzUserStore();
                store.SetPasswordHashAsync(admin, new EleganzUserManager().PasswordHasher.HashPassword("eleganzadmin"));
                store.SetPasswordHashAsync(user, new EleganzUserManager().PasswordHasher.HashPassword("eleganzuser"));
            }

            context.SaveChanges();
        }
    }
}
