using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class IMSContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                @"Host=localhost;Port=5432;Database=IMS;Username=postgres;Password=12345;",
                npgsqlOptions => npgsqlOptions.EnableRetryOnFailure());
        }

        public DbSet<Product> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}