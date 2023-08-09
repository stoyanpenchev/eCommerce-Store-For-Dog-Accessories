using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder
					.HasOne(c => c.User)
					.WithOne(u => u.ActiveCart)
					.HasForeignKey<Cart>(c => c.UserId)
					.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
