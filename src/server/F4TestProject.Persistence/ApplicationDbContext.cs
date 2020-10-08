using F4TestProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace F4TestProject.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }


}
