using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Data;

public class DatabaseContext : DbContext
{
    // public DbSet<> wfawfawf { get; set; }
    // public DbSet<> wfawfawf { get; set; }
    // public DbSet<> wfawfawf { get; set; }
    // public DbSet<> wfawfawf { get; set; }
    // public DbSet<> wfawfawf { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<>().HasData(new List<>()
        // {
        //     
        // });
        //
        // modelBuilder.Entity<>().HasData(new List<>()
        // {
        //     
        // });
        //
        // modelBuilder.Entity<>().HasData(new List<>()
        // {
        //     
        // });
        //
        // modelBuilder.Entity<>().HasData(new List<>()
        // {
        //     
        // });
        //
        // modelBuilder.Entity<>().HasData(new List<>()
        // {
        //     
        // });
        
    }
    
}