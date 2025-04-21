using IDSmarters.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using IDSmarters.Infrastructure.Data;

using System;
using IDSmarter.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure (DbContext)
builder.Services.AddInfrastructure(builder.Configuration);

// Add Identity with Role
builder.Services.AddIdentity<ApplicationUser, IdentityRole>() 
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");  

app.UseAuthentication(); 
app.UseAuthorization();

// 📌 Map API endpoints
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // 1. Seed Roles
        string[] roles = { "Admin", "Dean", "Instructor", "Student" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // 2. Seed Admin
        var adminEmail = "admin@idsmarters.com";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new ApplicationUser
            {
                UserName = "superadmin",
                Email = adminEmail,
                FirstName = "IDSC",
                LastName = "Ligao"
            };

            await userManager.CreateAsync(admin, "Admin@1234");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        // 3. Seed Deans (one per department)
        string[] departments = { "HM", "TM", "IT", "BA", "CRIM", "EDUC", "SHS" };
        foreach (var dept in departments)
        {
            var deanEmail = $"dean.{dept.ToLower()}@idsmarters.com";
            if (await userManager.FindByEmailAsync(deanEmail) == null)
            {
                var dean = new ApplicationUser
                {
                    UserName = $"dean_{dept}",
                    Email = deanEmail,
                    FirstName = "Dean",
                    LastName = dept,
                    Department = dept // Add Department property to ApplicationUser
                };

                await userManager.CreateAsync(dean, $"Dean.{dept}@1234");
                await userManager.AddToRoleAsync(dean, "Dean");
            }
        }

        // 4. Seed 10 Instructors
        for (int i = 1; i <= 10; i++)
        {
            var instructorEmail = $"instructor{i}@idsmarters.com";
            if (await userManager.FindByEmailAsync(instructorEmail) == null)
            {
                var instructor = new ApplicationUser
                {
                    UserName = $"instructor_{i}",
                    Email = instructorEmail,
                    FirstName = $"Instructor",
                    LastName = $"#{i}",
                    Department = departments[i % departments.Length] // Assign rotating departments
                };

                await userManager.CreateAsync(instructor, $"Instructor{i}@1234");
                await userManager.AddToRoleAsync(instructor, "Instructor");
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Seeding failed");
    }
}

app.Run();


