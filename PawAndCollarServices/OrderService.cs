using PawAndCollar.Data;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;
using static PawAndCollar.Common.EntittyValidationConstants;

namespace PawAndCollarServices
{
	using Microsoft.Data.SqlClient;
	using Microsoft.EntityFrameworkCore;
    using PawAndCollar.Data.Models;
    using PawAndCollar.Data.Models.Enums;
    using PawAndCollar.Data.Models.Models;
    using PawAndCollar.Services.Data.Models.Order;
    using PawAndCollar.Web.ViewModels.Order.Enums;

    public class OrderService : IOrderService
    {
        private readonly PawAndCollarDbContext dbContext;
        public OrderService(PawAndCollarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddOrderSummaryAsync(OrderSummaryViewModel model, string userId)
        {
            Order? existingOrder = await this.dbContext.Orders
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
            if (cart == null)
            {
                throw new InvalidOperationException("Cart is empty or not found");
            }
            if (cart.OrderedItems.Any(oi => !oi.Product.IsActive))
            {
                throw new InvalidOperationException("One or more products are not available");
            }

            ICollection<Product> products = cart.OrderedItems.Select(oi => oi.Product).ToList();
            user.BuyedProducts.AddRange(products);

            foreach (var orderedItem in cart.OrderedItems)
            {
                var product = orderedItem.Product;
                var quantityToPurchase = orderedItem.Quantity;

                product.Quantity -= quantityToPurchase;
                if(product.Quantity == 0)
                {
                    product.IsActive = false;
                }
                await this.dbContext.UsersBuyedProducts.AddAsync(new UsersBuyedProducts
                {
                    ProductId = product.Id,
                    UserId = Guid.Parse(userId),
                    Quantity = orderedItem.Quantity,
                    OrderId = existingOrder.Id
                });
                //existingOrder.UserBuyedProducts.Add(new UsersBuyedProducts
                //{
                //    ProductId = product.Id,
                //    UserId = Guid.Parse(userId),
                //    Quantity = orderedItem.Quantity
                //});
                
            }
            
            cart.TotalPrice = 0;
            cart.OrderedItems.Clear();

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AllOrdersFilteredAndPagedServiceModel> GetAllOrdersAsync(AllOrdersQueryModel queryModel)
        {
            IQueryable<Order> ordersQuery = this.dbContext.Orders
                .Where(o => o.Status != OrderStatus.Cancelled)
                .AsQueryable();
            int status = 0;
            if (!string.IsNullOrEmpty(queryModel.Status))
            {
                status = (int)Enum.Parse(typeof(OrderStatus), queryModel.Status);
                ordersQuery = ordersQuery.Where(o => o.Status == (OrderStatus)status);
            }

            ordersQuery = queryModel.OrderSorting switch
            {
                OrderSorting.TotalPriceDescending => ordersQuery.OrderByDescending(o => o.TotalAmount),
                OrderSorting.TotalPriceAscending => ordersQuery.OrderBy(o => o.TotalAmount),
                OrderSorting.Oldest => ordersQuery.OrderBy(o => o.OrderDate),
                OrderSorting.Newest => ordersQuery.OrderByDescending(o => o.OrderDate),
                _ => ordersQuery.OrderByDescending(o => o.OrderDate)
            };

            IEnumerable<OrderViewModel> orders = await ordersQuery
                .Where(o => o.Status != OrderStatus.Cancelled)
                .Skip((queryModel.CurrentPage - 1) * queryModel.OrdersPerPage)
                .Take(queryModel.OrdersPerPage)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id.ToString(),
                    CustomerName = o.CustomerName,
                    OrderDate = o.OrderDate.ToString("yyyy-MM-dd HH:mm"),
                    PhoneNumber = o.Phone,
                    Email = o.Customer.Email,
                    Status = o.Status.ToString(),
                    TotalPrice = o.TotalAmount
                }).ToListAsync();

            int totalOrders = await ordersQuery.CountAsync();
            return new AllOrdersFilteredAndPagedServiceModel
            {
                Orders = orders,
                TotalOrdersCount = totalOrders
            };
        }

        public async Task<ICollection<string>> GetAllOrderStatusesAsync()
        {
            ICollection<string> orderStats = await this.dbContext.Orders
                .Where(o => o.Status != OrderStatus.Cancelled)
                .Select(o => o.Status.ToString())
                .Distinct()
                .ToListAsync();
            return orderStats;
        }

		public async Task<OrderDetailsViewModel> GetOrderDetailsAsync(string id)
		{
            OrderDetailsViewModel? model = await this.dbContext.Orders
                .Include(o => o.OrderedItems)
                .ThenInclude(oi => oi.Order)
				.Where(o => o.Id.ToString() == id)
				.Select(o => new OrderDetailsViewModel
                {
                    Id = o.Id.ToString(),
					CustomerName = o.CustomerName,
					OrderDate = o.OrderDate.ToString("yyyy-MM-dd HH:mm"),
					OrderNumber = o.OrderNumber.ToString(),
					PaymentMethod = o.PaymentMethod.ToString(),
                    Email = o.Customer.Email,
					PhoneNumber = o.Phone,
					ShippingAddress = o.ShippingAddress,
					Status = o.Status.ToString(),
					TotalPrice = o.TotalAmount,
                    OrderedItems = o.UserBuyedProducts
                    .Where(oi => oi.OrderId == o.Id)
                    .Select(oi => new OrderSummaryProductViewModel
                    {
                        Id = oi.Product.Id,
                        Name = oi.Product.Name,
                        Price = oi.Product.Price,
                        Quantity = oi.Quantity
                    }).ToList()
				}).FirstOrDefaultAsync();

            return model;
		}

		public async Task<Guid> GetOrderNumberAsync(string userId)
        {
            Order? order = await this.dbContext.Orders
                .FirstOrDefaultAsync(o => o.Customer.Id == Guid.Parse(userId));
            if (order != null)
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
                .Where(o => o.Customer.Id == Guid.Parse(userId))
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();
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

        public async Task UpdateOrderStatusAsync(OrderDetailsViewModel viewModel)
        {
            Order? order = await this.dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id.ToString() == viewModel.Id);
            if (order != null)
            {
                order.Status = viewModel.Status switch
                {
                    "Processing" => order.Status = OrderStatus.Processing,
                    "Shipped" => order.Status = OrderStatus.Shipped,
                    "Delivered" => order.Status = OrderStatus.Delivered,
                    "Cancelled" => order.Status = OrderStatus.Cancelled,
                    _ => order.Status = OrderStatus.Processing
                };
            }
            await this.dbContext.SaveChangesAsync();
        }
    }
}
