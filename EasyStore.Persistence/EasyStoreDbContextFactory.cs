using System;
using EasyStore.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyStore.Persistence
{
    public class EasyStoreDbContextFactory : DesignTimeDbContextFactoryBase<EasyStoreDbContext>
    {
        protected override EasyStoreDbContext CreateNewInstance(DbContextOptions<EasyStoreDbContext> options)
        {
            return new EasyStoreDbContext(options);
        }
    }
}
