﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => new { oi.OrderId, oi.ProductId });
            builder
                .HasOne(o => o.Order)
                .WithMany(oi => oi.OrderedItems)
                .HasForeignKey(o => o.OrderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderedItems)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
