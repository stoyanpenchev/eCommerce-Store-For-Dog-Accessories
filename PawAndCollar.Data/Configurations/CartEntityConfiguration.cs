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

			builder.HasData(this.GenerateCarts());
		}

		private Cart[] GenerateCarts()
		{
			ICollection<Cart> carts = new List<Cart>();

			Cart cart = new Cart()
			{
				Id = Guid.Parse("36F85CB2-39E3-4D82-BC1D-BFDDB6B3F13F"),
				UserId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				TotalPrice = 0
			};
			carts.Add(cart);

			cart = new Cart()
			{
				Id = Guid.Parse("F91F214B-123D-47F1-9BDC-E97DFADC431B"),
				UserId = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
				TotalPrice = 0
			};
			carts.Add(cart);

			return carts.ToArray();
		}
	}
}
