using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _3_Asp.Net_MVC.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext() { }
        public ShoppingDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SHANGHAIK;Initial Catalog=IT17301_Shopping;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
