using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Web.ViewModels.Cart;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class CartService : ICartService
	{
		private readonly PawAndCollarDbContext dbContext;

		public CartService(PawAndCollarDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddToCartAsync(string userId, int productId)
		{
			Cart? cart = await this.dbContext.Carts
				.Include(c => c.OrderedItems)
				.ThenInclude(oi => oi.Order)
				.FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

			ApplicationUser user = await this.dbContext.Users
				.Include(u => u.ActiveCart)
				.FirstAsync(u => u.Id.ToString() == userId);

			if (user.ActiveCart == null)
			{
				cart = new Cart
				{
					UserId = Guid.Parse(userId)
				};
				user.CartId = cart.Id;
				await this.dbContext.Carts.AddAsync(cart);
				await this.dbContext.SaveChangesAsync();
			}

			OrderItem? orderItem = user.ActiveCart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);

			if (orderItem != null)
			{
				orderItem.Quantity += 1;
			}
			else
			{
				Product product = await this.dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
				Order order = new Order
				{
					CustomerId = cart.UserId, // Assuming the user is the customer for the order
					OrderDate = DateTime.Now, // Set the order date to the current date/time
					Status = OrderStatus.Pending, // Set the initial status of the order
					TotalAmaunt = cart.TotalPrice, // Set the total amount of the order
					ShippingAddress = "", // Set the shipping address
					PaymentMethod = PaymentTypes.None // Set the payment method
				};

				orderItem = new OrderItem
				{
					Product = product,
					Quantity = 1,
					Order = order,
					Cart = cart
				};

				cart.OrderedItems.Add(orderItem);
				await this.dbContext.OrderedItems.AddAsync(orderItem);
			}
			await this.dbContext.SaveChangesAsync();
		}

		public async Task DecreaseQuantityAsync(string userId, int productId)
		{
			Cart? cart = await this.dbContext.Carts
				.Include(c => c.OrderedItems)
				.FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));
			if (cart != null)
			{
				OrderItem? orderItem = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);
				if (orderItem != null && orderItem.Quantity >= 1 && orderItem.Product.IsActive)
				{
					orderItem.Quantity -= 1;
					await this.dbContext.SaveChangesAsync();
				}
			}
		}

		public async Task<ViewCartViewModel> GetCartItemsAsync(string userId)
		{
			ApplicationUser user = await this.dbContext.Users
				.Include(u => u.ActiveCart)
				.ThenInclude(c => c.OrderedItems)
				.ThenInclude(oi => oi.Product)
				.FirstAsync(u => u.Id.ToString() == userId);
			if (user.ActiveCart == null)
			{
				Cart cart = new Cart()
				{
					UserId = Guid.Parse(userId)
				};
				user.CartId = cart.Id;
				await this.dbContext.Carts.AddAsync(cart);
				await this.dbContext.SaveChangesAsync();
			}
			ViewCartViewModel cartViewModel = new ViewCartViewModel();

			cartViewModel.CartItems = user.ActiveCart.OrderedItems.Select(oi => new CartItemViewModel
			{
				Id = oi.ProductId,
				Description = oi.Product.Description,
				ImageUrl = oi.Product.ImageUrl,
				Name = oi.Product.Name,
				Price = oi.Product.Price,
				TotalPrice = oi.Product.Price * oi.Quantity,
				Quantity = oi.Quantity
			}).ToList();
			return cartViewModel;
		}

		public async Task<string> GetCartItemsCountAsync(string userId)
		{
			Cart? cart = await this.dbContext.Carts
				.Include(c => c.OrderedItems)
				.ThenInclude(c => c.Product)
				.FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));
			if (cart != null)
			{
				string count = cart.OrderedItems.Count().ToString();
				return count;
			}
			return "0";
		}

		public async Task IncreaseQuantityAsync(string userId, int productId)
		{
			Cart? cart = await this.dbContext.Carts
				.Include(c => c.OrderedItems)
				.ThenInclude(c => c.Product)
				.FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));
			if (cart != null)
			{
				OrderItem? orderItem = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);
				if (orderItem != null && orderItem.Product.Quantity >= 1 && orderItem.Product.IsActive)
				{
					orderItem.Quantity += 1;
					await this.dbContext.SaveChangesAsync();
				}
			}

		}

		public async Task RemoveItemFromCart(string userId, int productId)
		{
			Cart? cart = await this.dbContext.Carts
				.Include(c => c.OrderedItems)
				.FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));
			if (cart != null)
			{
				OrderItem? orderItem = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);
				if (orderItem != null)
				{
					cart.OrderedItems.Remove(orderItem);
					await this.dbContext.SaveChangesAsync();
				}
			}

		}
	}
}
