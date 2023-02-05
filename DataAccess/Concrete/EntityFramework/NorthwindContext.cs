using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;
public class NorthwindContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Sertifika ile ilgili bir error alırsan Trust Server Certificate=true ekle.
        string connectionString = @"Server=ERHANMATEBOOK;Database=Northwind;Trusted_Connection=true;Trust Server Certificate=true";
        optionsBuilder.UseSqlServer(connectionString);
    }
    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}
}