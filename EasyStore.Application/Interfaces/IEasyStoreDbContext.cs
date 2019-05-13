using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Interfaces
{
    public interface IEasyStoreDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderedItem> OrderedItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
