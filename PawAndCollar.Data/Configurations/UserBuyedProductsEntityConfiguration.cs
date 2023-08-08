using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class UserBuyedProductsEntityConfiguration : IEntityTypeConfiguration<UsersBuyedProducts>
	{
		public void Configure(EntityTypeBuilder<UsersBuyedProducts> builder)
		{
			builder.HasData(this.GetUsersBuyedProducts());
		}

		private UsersBuyedProducts[] GetUsersBuyedProducts()
		{
			ICollection<UsersBuyedProducts> usersBuyedProducts = new List<UsersBuyedProducts>();

			UsersBuyedProducts usersBuyedProduct = new UsersBuyedProducts()
			{
				Id = Guid.Parse("0D5FF8A7-C4E0-4DB5-89DF-2801A2CD945F"),
				UserId = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
				ProductId = 1,
				Quantity = 2,
				OrderId = Guid.Parse("AD8F6D52-9E4D-463A-B240-723C2E37AC2B")
			};
			usersBuyedProducts.Add(usersBuyedProduct);

			usersBuyedProduct = new UsersBuyedProducts()
			{
				Id = Guid.Parse("96A247B6-51A7-4F42-800F-3150B014358C"),
				UserId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				ProductId = 8,
				Quantity = 1,
				OrderId = Guid.Parse("07D0B51A-BF10-4BAE-8E3F-268D08B4F715")
			};
			usersBuyedProducts.Add(usersBuyedProduct);

			usersBuyedProduct = new UsersBuyedProducts()
			{
				Id = Guid.Parse("D7C7A078-A1AF-42F3-B271-403D7CD05444"),
				UserId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				ProductId = 11,
				Quantity = 2,
				OrderId = Guid.Parse("4D9C7A77-9295-4A6E-907A-96FE2905DE0E")
			};
			usersBuyedProducts.Add(usersBuyedProduct);

			usersBuyedProduct = new UsersBuyedProducts()
			{
				Id = Guid.Parse("2A00F9CA-8B95-487F-9BCB-41588AB9C532"),
				UserId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				ProductId = 12,
				Quantity = 1,
				OrderId = Guid.Parse("4D9C7A77-9295-4A6E-907A-96FE2905DE0E")
			};
			usersBuyedProducts.Add(usersBuyedProduct);

			return usersBuyedProducts.ToArray();
		}
	}
}
