using Microsoft.EntityFrameworkCore;
using EventManagementSystemADV.Models;

namespace EventManagementSystemADV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
