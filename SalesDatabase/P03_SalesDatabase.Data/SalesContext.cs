using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Configurations;
using P03_SalesDatabase.Data.Models;
using static P03_SalesDatabase.Data.ApplicationCommonConfiguration;

namespace P03_SalesDatabase.Data
{
    public class SalesContext:DbContext
    {
        public  SalesContext()
        {

        }
        public SalesContext(DbContextOptions options) :base( options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);

        }

    }
}
