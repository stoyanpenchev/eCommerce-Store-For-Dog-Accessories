﻿using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Web.ViewModels.User;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class ApplicationUserService : IApplicationUserService
	{
		private readonly PawAndCollarDbContext dbContext;
		private readonly ICreatorService creatorService;
		public ApplicationUserService(PawAndCollarDbContext dbContext, ICreatorService creatorService)
		{
			this.dbContext = dbContext;
			this.creatorService = creatorService;
		}

		public async Task<IEnumerable<ApplicationUserViewModel>> AllAsync()
		{
			List<ApplicationUserViewModel> allUsers = await this.dbContext.Users
				.Where(c => (bool)c.IsActive)
				.Select(c => new ApplicationUserViewModel()
				{
					Id = c.Id.ToString(),
					Email = c.Email
				}).ToListAsync();


			foreach (ApplicationUserViewModel user in allUsers)
			{
				user.OpenOrders = await this.IsItHaveOpenOrders(user.Id);


				Creator? creator = await this.dbContext.Creators
					.FirstOrDefaultAsync(c => c.UserId.ToString() == user.Id);

				if (creator != null)
				{
					user.PhoneNumber = creator.PhoneNumber;
				}
				else
				{
					user.PhoneNumber = string.Empty;
				}
			}
			return allUsers;

		}

		public async Task DeleteUserAsync(Guid id)
		{
			ApplicationUser? user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (user != null)
			{
				string randomValue = GenerateRandomValue();
				user.Email = randomValue;
				user.NormalizedEmail = randomValue;

				user.UserName = randomValue;
				user.NormalizedUserName = randomValue;
				user.PasswordHash = randomValue;
				user.CartId = null;
				bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(id.ToString());
				if (isCreator)
				{
					user.PhoneNumber = randomValue;
				}
				user.IsActive = false;
				await this.dbContext.SaveChangesAsync();
			}
			bool isItCreator = await this.creatorService.CreatorExistByUserIdAsync(id.ToString());
			if (isItCreator)
			{
				string creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(id.ToString());
				List<Product> products = await this.dbContext.Products.Where(p => p.CreatorId == Guid.Parse(creatorId)).ToListAsync();
				foreach (Product product in products)
				{
					product.IsActive = false;
					product.Quantity = 0;
					await this.dbContext.SaveChangesAsync();
				}
			}
		}

		public async Task<ApplicationUserViewModel> GetUserByIdAsync(Guid id)
		{
			ApplicationUserViewModel? user = await this.dbContext.Users
				.Select(c => new ApplicationUserViewModel()
				{
					Id = c.Id.ToString(),
					Email = c.Email
				}).FirstOrDefaultAsync(u => u.Id == id.ToString());
			if (user == null)
			{
				return null;
			}
			user.OpenOrders = await this.IsItHaveOpenOrders(user.Id);
			return user;
		}

		public async Task<bool?> IsItHaveOpenOrders(string userId)
		{
			ApplicationUserViewModel? user = await this.dbContext.Users
				.AsNoTracking()
				.Select(c => new ApplicationUserViewModel()
				{
					Id = c.Id.ToString(),
					Email = c.Email
				}).FirstOrDefaultAsync(u => u.Id == userId);

			user.OpenOrders = this.dbContext.Users
				   .AsNoTracking()
				   .Where(u => u.Id == Guid.Parse(user.Id))
				   .Any(o => o.Orders.Any(or => or.Status != OrderStatus.Cancelled && or.Status != OrderStatus.Delivered));

			bool? openOrders = user.OpenOrders;
			return openOrders;
		}

		private string GenerateRandomValue()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var random = new Random();
			var randomValue = new string(Enumerable.Repeat(chars, 10)
				.Select(s => s[random.Next(s.Length)]).ToArray());

			// Check if the generated value is already used in the database
			// If it is, generate a new one until a unique value is found
			while (dbContext.Users.Any(u => u.Email == randomValue || u.UserName == randomValue))
			{
				randomValue = new string(Enumerable.Repeat(chars, 10)
					.Select(s => s[random.Next(s.Length)]).ToArray());
			}

			return randomValue;
		}

	}
}
