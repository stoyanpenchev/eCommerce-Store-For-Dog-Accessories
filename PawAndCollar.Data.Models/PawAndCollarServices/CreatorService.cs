using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class CreatorService : ICreatorService
	{
		private readonly PawAndCollarDbContext dbContext;
		public CreatorService(PawAndCollarDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task AddProductAsync(AddProductViewModel model, string id)
		{
			var creator = this.dbContext.Creators.FirstOrDefault(c => c.UserId == Guid.Parse(id));
			if (creator != null)
			{
				Product product = new Product
				{
					Name = model.Name,
					Description = model.Description,
					Price = model.Price,
					Quantity = model.Quantity,
					ImageUrl = model.ImageUrl,
					CategoryId = model.CategoryId,
					CreatorId = creator.Id,
					Size = (SizeTypes)model.Size,
					Color = model.Color,
					Material = model.Material
				};
				await this.dbContext.Products.AddAsync(product);
				await this.dbContext.SaveChangesAsync();
			}



		}

        public async Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber)
        {
            return await this.dbContext.Creators.AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<bool> AgentExistByUserIdAsync(string userId)
		{
			bool result = await this.dbContext.Creators.AnyAsync(c => c.UserId == Guid.Parse(userId));
			return result;
		}

        public async Task Create(string userId, BecomeCreatorFormModel model)
        {
            Creator creator = new Creator
			{
                UserId = Guid.Parse(userId),
                PhoneNumber = model.PhoneNumber
            };
			await this.dbContext.Creators.AddAsync(creator);
			await this.dbContext.SaveChangesAsync();
        }
    }
}
