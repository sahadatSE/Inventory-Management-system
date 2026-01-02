using Database.Model;
using Database.ViewModel;
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
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Role> Role { get; set; }

        //ViewModels
        public DbSet<UserRoleInfo> UserRoleInfo { get; set; }
    }
}