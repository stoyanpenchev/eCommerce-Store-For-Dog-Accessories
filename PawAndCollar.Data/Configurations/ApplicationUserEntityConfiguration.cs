using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder
			.HasOne(u => u.ActiveCart)
			.WithOne(c => c.User)
			.HasForeignKey<Cart>(c => c.UserId)
			.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
