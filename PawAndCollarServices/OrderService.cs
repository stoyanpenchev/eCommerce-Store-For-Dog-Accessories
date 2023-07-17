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
            Order existingOrder = await this.dbContext.Orders
                .Include(o => o.OrderedItems)
                .FirstOrDefaultAsync(o => o.CustomerId == Guid.Parse(userId) && o.Status == OrderStatus.Pending);

            ApplicationUser? user = await this.dbContext.Users
                .Include(u => u.BuyedProducts)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (existingOrder == null)
            {
                    
                existingOrder = new Order
                {
                    CustomerId = Guid.Parse(userId),
                    PaymentMethod = (PaymentTypes)model.PaymentMethod,
                    OrderDate = DateTime.UtcNow,
                    Status = OrderStatus.Processing,
                    ShippingAddress = model.ShippingAddress,
                    CustomerName = model.CustomerName,
                    Phone = model.Phone,
                    //TotalAmount = model.OrderedItems.Sum(oi => oi.TotalPrice)
                };

                await this.dbContext.Orders.AddAsync(existingOrder);
            }
            else
            {
                existingOrder.PaymentMethod = (PaymentTypes)model.PaymentMethod;
                existingOrder.ShippingAddress = model.ShippingAddress;
                existingOrder.CustomerName = model.CustomerName;
                existingOrder.Phone = model.Phone;
                existingOrder.Status = OrderStatus.Processing;
                existingOrder.OrderDate = DateTime.UtcNow;
            }

            Cart? cart = await this.dbContext.Carts
                .Include(c => c.OrderedItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (cart != null)
            {
                ICollection<Product> products = cart.OrderedItems.Select(oi => oi.Product).ToList();
                user.BuyedProducts.AddRange(products);
                foreach (var product in products)
                {
                    await this.dbContext.UsersBuyedProducts.AddAsync(new UsersBuyedProducts
                    {
                        ProductId = product.Id,
                        UserId = Guid.Parse(userId),
                        Quantity = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == product.Id).Quantity
                    }); 
                }
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
