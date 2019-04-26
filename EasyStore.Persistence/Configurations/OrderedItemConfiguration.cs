using System;
using EasyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStore.Persistence.Configurations
{
    public class OrderedItemConfiguration : IEntityTypeConfiguration<OrderedItem>
    {
        public void Configure(EntityTypeBuilder<OrderedItem> builder)
        {
            builder.HasKey(o => new { o.OrderedItemId, o.ProductId });

            builder.HasOne(i => i.Order)
                .WithMany(o => o.OrderedItems)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedItems_Orders");

            builder.HasOne(o => o.Product)
                .WithMany(p => p.OrderedItems)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedItems_Products");

            builder.OwnsOne(i => i.Price)
                   .Property(p => p.Value)
                   .HasColumnName("Price");

        }
    }
}
