﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models;

namespace PawAndCollar.Data.Configurations
{
	public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{

			builder.Property(p => p.Price)
			       .HasColumnType("decimal(18,2)");
			builder
				.Property(p => p.CreatedOn)
				.HasDefaultValueSql("GETDATE()");
			builder
				.HasOne(h => h.Creator)
				.WithMany(a => a.Products)
				.HasForeignKey(h => h.CreatorId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(h => h.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(h => h.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
