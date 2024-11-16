using Microsoft.EntityFrameworkCore;
using Proje_OOP.Entity;

namespace Proje_OOP.ProjeContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-9TTU5F0\SQLEXPRESS;database=DbNewOopCore;Integrated Security=true;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Catogory> Catogories { get; set; }
    }
}
