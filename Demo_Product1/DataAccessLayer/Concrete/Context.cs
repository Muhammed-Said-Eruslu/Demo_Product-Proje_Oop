using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9TTU5F0\\SQLEXPRESS;Database=Demo_Product1;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get;set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
