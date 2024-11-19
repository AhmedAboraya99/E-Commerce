using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Product> products { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<PaymentCard> paymentCards { get; set; }

    }
}
