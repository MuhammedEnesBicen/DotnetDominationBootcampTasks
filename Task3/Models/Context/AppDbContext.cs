using Microsoft.EntityFrameworkCore;

namespace Task3.Models.Context
{
    public class AppDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //(localdb)\MSSQLLocalDB    @
            // optionsBuilder.UseSqlServer("Server=DESKTOP-5Q2O2JF;Database=BootcampTask3;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BootcampTask3;Trusted_Connection=True;"); 
        }

       public DbSet<Employee> Employees { get; set; }
    }
}
