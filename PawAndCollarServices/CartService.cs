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
            ApplicationUser? user = await this.dbContext.Users
                .Include(u => u.ActiveCart)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user!.ActiveCart == null)
            {
                Cart cart = new Cart
                {
                    UserId = Guid.Parse(userId)
                };
                user.CartId = cart.Id;
                await this.dbContext.Carts.AddAsync(cart);
            }

            Order? order = await this.dbContext.Orders
                .Include(o => o.OrderedItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.CustomerId == Guid.Parse(userId) && o.Status == OrderStatus.Pending);

            Product? product = await this.dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                throw new ArgumentException("Product not found!");
            }

            if (order == null)
            {
                order = new Order
                {
                    CustomerId = Guid.Parse(userId),
                    OrderDate = DateTime.Now,
                    Status = OrderStatus.Pending,
                    ShippingAddress = "",
                    CustomerName = user.UserName,
                    PaymentMethod = PaymentTypes.Cash,
                    OrderNumber = Guid.NewGuid()
                };
                await this.dbContext.Orders.AddAsync(order);
            }

            OrderItem orderItem = new OrderItem
            {
                Product = product,
                Quantity = 1,
                Order = order,
                Cart = user.ActiveCart
            };

            order.TotalAmount += order.OrderedItems.Sum(oi => oi.Product.Price * oi.Quantity);

            user?.ActiveCart?.OrderedItems.Add(orderItem);
            await this.dbContext.OrderedItems.AddAsync(orderItem);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DecreaseQuantityAsync(string userId, int productId)
        {
            Cart? cart = await this.dbContext.Carts
                .Include(c => c.OrderedItems)
                .ThenInclude(o => o.Order)
                .FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));
            if (cart != null)
            {
                Order? order = await this.dbContext.Orders
                    .Include(o => o.OrderedItems)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.CustomerId == Guid.Parse(userId) && o.Status == OrderStatus.Pending);
                OrderItem? orderItem = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);
                if (orderItem != null && orderItem.Quantity >= 1)
                {
                    if (order != null)
                    {
                        order.TotalAmount -= orderItem.Product.Price;
                    }
                    orderItem.Quantity -= 1;
                    if (orderItem.Quantity == 0)
                    {
                        cart.OrderedItems.Remove(orderItem);
                        this.dbContext.OrderedItems.Remove(orderItem);
                    }
                    await this.dbContext.SaveChangesAsync();
                }
                if (cart.OrderedItems.Count() == 0)
                {
                    orderItem.Order.Status = OrderStatus.Cancelled;
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
                Order? order = await this.dbContext.Orders
                    .Include(o => o.OrderedItems)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.CustomerId == Guid.Parse(userId) && o.Status == OrderStatus.Pending);

                OrderItem? orderItem = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);
                if (orderItem != null && orderItem.Product.Quantity >= 1 && orderItem.Product.IsActive)
                {
                    if(order != null)
                    {
                        order.TotalAmount += orderItem.Product.Price;
                    }
                    orderItem.Quantity += 1;
                    await this.dbContext.SaveChangesAsync();
                }
            }

        }

        public async Task RemoveItemFromCart(string userId, int productId)
        {
            Cart? cart = await this.dbContext.Carts
                .Include(c => c.OrderedItems)
                .ThenInclude(c => c.Order)
                .FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));
            if (cart != null)
            {
                OrderItem? orderItem = cart.OrderedItems.FirstOrDefault(oi => oi.ProductId == productId);
                if (orderItem != null)
                {
                    cart.OrderedItems.Remove(orderItem);
                    await this.dbContext.SaveChangesAsync();
                }
                if (cart.OrderedItems.Count() == 0)
                {
                    orderItem.Order.Status = OrderStatus.Cancelled;
                    await this.dbContext.SaveChangesAsync();
                }
            }

        }
    }
}
