using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Data;

public class DatabaseContext : DbContext
{
    // public DbSet<Customer> Customers { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        // {
        //     new Customer() { CustomerId = 1, FirstName = "John", LastName = "Doe" },
        // });
        
    }
    
}