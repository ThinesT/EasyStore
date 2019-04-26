using System;
using EasyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStore.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            builder.OwnsOne(o => o.Billings, a =>
            {
                a.Property(p => p.Address_1).HasColumnName("BillingAddress_1");
                a.Property(p => p.Address_2).HasColumnName("BillingAddress_2");
                a.Property(p => p.City).HasColumnName("BillingCity");
                a.Property(p => p.Country).HasColumnName("BillingCountry");
                a.OwnsOne(p => p.EmailAddress).Property(e => e.Value).HasColumnName("BillingEmail");
                a.Property(p => p.ZipCode).HasColumnName("BillingZipCode");
            });

            builder.OwnsOne(o => o.Shippings, a =>
            {
                a.Property(p => p.Address_1).HasColumnName("ShippingAddress_1");
                a.Property(p => p.Address_2).HasColumnName("ShippingAddress_2");
                a.Property(p => p.City).HasColumnName("ShippingCity");
                a.Property(p => p.Country).HasColumnName("ShippingCountry");
                a.OwnsOne(p => p.EmailAddress).Property(e => e.Value).HasColumnName("ShippingEmail");
                a.Property(p => p.ZipCode).HasColumnName("ShippingZipCode");
            });


        }
    }
}
