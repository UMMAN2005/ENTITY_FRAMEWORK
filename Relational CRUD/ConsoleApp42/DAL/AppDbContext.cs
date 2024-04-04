using Microsoft.EntityFrameworkCore;
using ConsoleApp42.Models;

namespace ConsoleApp42.DAL {
    internal class AppDbContext : DbContext {

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=DELL-UMMAN\SQLEXPRESS;Database=Business;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
