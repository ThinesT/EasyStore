using System;
using EasyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStore.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.OwnsOne(c => c.Address, a =>
            {
                a.Property(p => p.Address_1).HasColumnName("CustomerAddress_1");
                a.Property(p => p.Address_2).HasColumnName("CustomerAddress_2");
                a.Property(p => p.City).HasColumnName("CustomerCity");
                a.Property(p => p.Country).HasColumnName("CustomerCountry");
                a.OwnsOne(p => p.EmailAddress).Property(e => e.Value).HasColumnName("CustomerEmail");
                a.Property(p => p.ZipCode).HasColumnName("CustomerZipCode");
            });

        }
    }
}
