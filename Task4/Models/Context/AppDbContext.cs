using Microsoft.EntityFrameworkCore;

namespace Task4.Models.Context
{
    public class AppDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BootcampTask3;Trusted_Connection=True;");
        }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
