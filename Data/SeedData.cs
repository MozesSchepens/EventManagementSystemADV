using EventManagementSystemADV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EventManagementSystemADV.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Categories.Any() || context.Volunteers.Any() || context.Events.Any())
                {
                    return; // Database bevat al data
                }

                context.Categories.AddRange(
                    new Category { Name = "Conference" },
                    new Category { Name = "Workshop" }
                );

                context.Volunteers.AddRange(
                    new Volunteer { FirstName = "John",LastName="Doe" ,Email = "john@example.com" },
                    new Volunteer { FirstName = "Jane",LastName="Smith", Email = "jane@example.com" }
                );

                context.Events.AddRange(
                    new Event
                    {
                        Name = "Tech Conference 2024",
                        Date = DateTime.Now.AddDays(30),
                        CategoryId = 1,
                        Volunteers = context.Volunteers.ToList()
                    },
                    new Event
                    {
                        Name = "Beginner Workshop",
                        Date = DateTime.Now.AddDays(60),
                        CategoryId = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
