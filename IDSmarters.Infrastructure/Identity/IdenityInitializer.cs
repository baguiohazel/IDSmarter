using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarters.Infrastructure.Identity
{
    public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Roles to seed (excluding Student)
        string[] roles = { "Admin", "Dean", "Instructor" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Seed default Admin user
        var adminUser = await userManager.FindByEmailAsync("admin@school.com");
        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = "admin@school.com",
                Email = "admin@school.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, "Admin123!");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }
    }
