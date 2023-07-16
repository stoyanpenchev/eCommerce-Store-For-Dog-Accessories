using PawAndCollar.Data;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;
using static PawAndCollar.Common.EntittyValidationConstants;

namespace PawAndCollarServices
{
	using Microsoft.EntityFrameworkCore;
	using PawAndCollar.Data.Models;
	using PawAndCollar.Data.Models.Enums;
	using PawAndCollar.Data.Models.Models;

	public class OrderService : IOrderService
	{
		private readonly PawAndCollarDbContext dbContext;
		public OrderService(PawAndCollarDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddOrderSummaryAsync(OrderSummaryViewModel model, string userId)
		{
			Order order = new Order()
			{
				CustomerId = Guid.Parse(userId),
				PaymentMethod = (PaymentTypes)model.PaymentMethod,
				OrderDate = DateTime.UtcNow,
				Status = OrderStatus.Processing,
				ShippingAddress = model.ShippingAddress,
				CustomerName = model.CustomerName,
				Phone = model.Phone,
			};
			

			await this.dbContext.Orders.AddAsync(order);

			Cart? cart = await this.dbContext.Carts
				.Include(c => c.OrderedItems)
				.ThenInclude(oi => oi.Product)
				.FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
			if(cart != null)
			{
				cart.OrderedItems.Clear();
			}
			await this.dbContext.SaveChangesAsync();
		}

        public async Task<Guid> GetOrderNumberAsync(string userId)
        {
            Order? order = await this.dbContext.Orders
                .FirstOrDefaultAsync(o => o.Customer.Id == Guid.Parse(userId));
			if(order != null)
			{
				  return order.OrderNumber;
			}
			return Guid.NewGuid();
        }

        public async Task<ICollection<OrderSummaryProductViewModel>> GetOrderSummaryProductAsync(string userId)
		{

			Order? order = await this.dbContext.Orders
				.Include(o => o.OrderedItems)
				.ThenInclude(op => op.Product)
				.FirstOrDefaultAsync(o => o.Customer.Id == Guid.Parse(userId));
			if (order != null)
			{

				ICollection<OrderSummaryProductViewModel> products = order.OrderedItems
					.Select(op => new OrderSummaryProductViewModel()
				{
					Id = op.ProductId,
					Name = op.Product.Name,
					Price = op.Product.Price,
					Quantity = op.Quantity
				}).ToList();


				return products;
			}
			else
			{
				return null;
			}
		}
	}
}
