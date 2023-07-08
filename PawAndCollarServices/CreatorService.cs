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
		
        public async Task<bool> CreatorExistByPhoneNumberAsync(string phoneNumber)
        {
            return await this.dbContext.Creators.AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<bool> CreatorExistByUserIdAsync(string userId)
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

		public async Task<string?> GetCreatorIdByUserIdAsync(string userId)
		{
			Creator? creator = await this.dbContext.Creators
				.FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
			if (creator == null)
			{
				return null;
			}
			return creator.Id.ToString();

		}
	}
}
