﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(p => p.IsActive)
				   .HasDefaultValue(true);

			builder
			.HasOne(u => u.ActiveCart)
			.WithOne()
			.HasForeignKey<ApplicationUser>(u => u.CartId)
			.OnDelete(DeleteBehavior.Restrict);

		}		
	}
}
