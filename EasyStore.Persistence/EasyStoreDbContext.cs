using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Persistence
{
    public class EasyStoreDbContext : DbContext, IEasyStoreDbContext
    {
        public EasyStoreDbContext(DbContextOptions<EasyStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EasyStoreDbContext).Assembly);
        }
    }
}