using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasData(this.GenerateOrders());
		}

		private Order[] GenerateOrders()
		{
			ICollection<Order> orders = new List<Order>();
			Order order = new Order()
			{
				Id = Guid.Parse("07D0B51A-BF10-4BAE-8E3F-268D08B4F715"),
				CustomerId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				OrderDate = DateTime.UtcNow,
				TotalAmount = 62.00M,
				Status = (OrderStatus)2,
				ShippingAddress = "Velcho Atanasov 56",
				PaymentMethod = (PaymentTypes)1,
				CustomerName = "Dogy Lover",
				OrderNumber = Guid.Parse("32C557E6-7EC5-4F8C-8924-3F263C936ED5"),
				Phone = "+359885179143"
			};
			orders.Add(order);

			order = new Order()
			{
				Id = Guid.Parse("4D9C7A77-9295-4A6E-907A-96FE2905DE0E"),
				CustomerId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				OrderDate = DateTime.UtcNow,
				TotalAmount = 132.00M,
				Status = (OrderStatus)2,
				ShippingAddress = "Velcho Atanasov 56",
				PaymentMethod = (PaymentTypes)1,
				CustomerName = "Dogy Lover",
				OrderNumber = Guid.Parse("2452C95C-8F69-4BB3-AE5C-203C95EA6D01"),
				Phone = "+359885179143"
			};
			orders.Add(order);

			order = new Order()
			{
				Id = Guid.Parse("AD8F6D52-9E4D-463A-B240-723C2E37AC2B"),
				CustomerId = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
				OrderDate = DateTime.UtcNow,
				TotalAmount = 104.00M,
				Status = (OrderStatus)3,
				ShippingAddress = "Sofia Bulgaria",
				PaymentMethod = (PaymentTypes)2,
				CustomerName = "Admin Adminov",
				OrderNumber = Guid.Parse("43CDAD61-ECB3-488E-A378-F5674399EAA4"),
				Phone = "+359884123154"
			};
			orders.Add(order);

			return orders.ToArray();
		}
	}
}
