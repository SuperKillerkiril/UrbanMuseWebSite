using UrbanMuse.Models;
using Microsoft.EntityFrameworkCore;

namespace UrbanMuse.DataBase;

public class ModelContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=UrbanMuseModels.db"); 
    }
}
