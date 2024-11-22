using EventManagementSystemADV.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystemADV.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Name = "Conferentie" },
                        new Category { Name = "Workshop" }
                    );
                    context.SaveChanges();
                }

                if (!context.Events.Any())
                {
                    context.Events.AddRange(
                        new Event { Name = "Tech Summit", Date = DateTime.Now.AddDays(10), CategoryId = 1, IsDeleted = false },
                        new Event { Name = "Coding Workshop", Date = DateTime.Now.AddDays(20), CategoryId = 2, IsDeleted = false }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
