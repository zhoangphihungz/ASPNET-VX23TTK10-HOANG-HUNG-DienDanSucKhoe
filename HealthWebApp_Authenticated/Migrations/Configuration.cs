using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HealthWebApp_Authenticated.Models;

namespace HealthWebApp_Authenticated.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HealthWebApp_Authenticated.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HealthWebApp_Authenticated.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Tạo vai trò Admin nếu chưa tồn tại
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // Tạo vai trò Editor nếu chưa tồn tại
            if (!roleManager.RoleExists("Editor"))
            {
                var role = new IdentityRole();
                role.Name = "Editor";
                roleManager.Create(role);
            }

            // SỬA LỖI: Kiểm tra nếu user admin chưa tồn tại thì mới tạo
            if (userManager.FindByName("admin@suckhoe.com") == null)
            {
                var user = new ApplicationUser { UserName = "admin@suckhoe.com", Email = "admin@suckhoe.com" };
                var password = "Password123!";

                var result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }

    }
}