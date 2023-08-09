using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollarServices.Interfaces;
using PawAndCollarServices;
using PawAndCollarSystem.Services.Tests.CreatorTests;
using System.Threading.Tasks;
using System;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using System.Collections.Generic;
using System.Linq;
using PawAndCollar.Web.ViewModels.User;
using PawAndCollar.Data.Models;

namespace PawAndCollarSystem.Services.Tests.ServiceTests
{
	using static DatabaseSeeder;
	public class ApplicationUsersServiceTests
	{
		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private ICreatorService creatorService;
		private IApplicationUserService userService;

		[OneTimeSetUp]
		public async Task OneTimeSetup()
		{
			this.dbOptions = new DbContextOptionsBuilder<PawAndCollarDbContext>()
				.UseInMemoryDatabase("PawAndCollarInMemory" + Guid.NewGuid().ToString())
				.Options;
			dbContext = new PawAndCollarDbContext(this.dbOptions, false);

			await dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.Database.EnsureCreatedAsync();
			SeedDatabase(dbContext);

			this.creatorService = new CreatorService(this.dbContext);
			this.userService = new ApplicationUserService(this.dbContext, this.creatorService);
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllUsersWithOpenOrders()
		{
			CreatorUser.Orders.Add(OrderCreator);
			User.Orders.Add(OrderUser);
			
			var result = await this.userService.AllAsync();

			Assert.AreEqual(2, result.Count());
		}

		[Test]
		public async Task DeleteUserAsync_ShouldDeleteUser()
		{

			Product product = new Product()
			{
				Id = 1,
				Name = "Checker Pink Collar",
				Description = "Soft and sustainable fabric on the outside & inside, so even the most sensitive pups can stay comfortable all day long.\r\nCozy Fleece Vest: Machine wash cold on delicate cycle or hand wash. Air dry.",
				Price = 52.00M,
				Quantity = 10,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC03178-1-148760_720x.jpg?v=1679180307",
				CategoryId = 1,
				CreatorId = CreatorUser.Id,
				Size = (SizeTypes)5,
				Color = "Pink",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			this.dbContext.Products.Add(product);
			Creator.Products.Add(product);
			this.dbContext.SaveChanges();

			await this.userService.DeleteUserAsync(User.Id);
			await this.userService.DeleteUserAsync(CreatorUser.Id);

			Assert.AreEqual(2, this.dbContext.Users.Count());
			Assert.True(User.CartId == null);
			Assert.True(CreatorUser.CartId == null);
			Assert.True(product.Quantity == 0);
			Assert.True(product.IsActive == false);
		}

		[Test]
		public async Task IsItHaveOpenOrders_ShouldReturnTrue()
		{

			OrderCreator.CustomerId = CreatorUser.Id;
			await this.dbContext.SaveChangesAsync();

			var result = await this.userService.IsItHaveOpenOrders(CreatorUser.Id.ToString());

			Assert.True(result);
		}

		[Test]
		public async Task IsItHaveOpenOrders_ShouldReturnFalse()
		{

			OrderCreator.CustomerId = CreatorUser.Id;
			OrderCreator.Status = (OrderStatus)5;
			await this.dbContext.SaveChangesAsync();

			var result = await this.userService.IsItHaveOpenOrders(CreatorUser.Id.ToString());

			Assert.False(result);
		}

		[Test]
		public async Task IsItHaveOpenOrders_ShouldReturnFalseWhenUserDoesntHaveOrders()
		{

			var result = await this.userService.IsItHaveOpenOrders(CreatorUser.Id.ToString());

			Assert.False(result);
		}

		[Test]
		public async Task GetUserByIdAsync_ShouldReturnUser()
		{

			var result = await this.userService.GetUserByIdAsync(CreatorUser.Id);

			Assert.AreEqual(CreatorUser.Id.ToString(), result.Id);
		}

		[Test]
		public async Task GetUserByIdAsync_ShouldReturnNull()
		{

			var result = await this.userService.GetUserByIdAsync(Guid.Empty);

			Assert.AreEqual(null, result);
		}

		
	}
}
