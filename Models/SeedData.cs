using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VulnerableBlazorApp.Data;

namespace VulnerableBlazorApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            if (context == null || context.Users == null)
            {
                throw new ArgumentNullException("Null ApplicationDbContext");
            }

            // Look for any users or roles.
            if (context.Users.Any() || context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

            context.Roles.AddRange(
                new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                }
            );

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "test@example.com",
                EmailConfirmed = true,
                NormalizedEmail = "TEST@EXAMPLE.COM",
                UserName = "test@example.com",
                NormalizedUserName = "TEST@EXAMPLE.COM"
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Password_0");

            context.Users.AddRange(
                adminUser
            );
            context.SaveChanges();
        }
    }
}