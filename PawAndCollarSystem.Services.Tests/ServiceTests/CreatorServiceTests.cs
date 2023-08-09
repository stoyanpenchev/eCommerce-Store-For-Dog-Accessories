using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollarServices;
using PawAndCollarServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace PawAndCollarSystem.Services.Tests.CreatorTests
{
	using static DatabaseSeeder;
	public class CreatorServiceTests
	{

		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private ICreatorService creatorService;

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
		}

		[Test]
		public async Task CreatorExistByUserIdAsyncShouldRetturnTrueWhenExists()
		{
			string existingCreatorUserId = CreatorUser.Id.ToString();
			bool result = await this.creatorService.CreatorExistByUserIdAsync(existingCreatorUserId);
			Assert.IsTrue(result);
		}

		[Test]
		public async Task CreatorExistByUserIdAsyncShouldRetturnFalseWhenNotExists()
		{
			string notExistingCreatorUserId = User.Id.ToString();
			bool result = await this.creatorService.CreatorExistByUserIdAsync(notExistingCreatorUserId);
			Assert.IsFalse(result);
		}


		[Test]
		public async Task CreatorExistByPhoneNumberAsyncShouldRetturnTrueWhenExists()
		{
			string existingCreatorPhoneNumber = Creator.PhoneNumber;
			bool result = await this.creatorService.CreatorExistByPhoneNumberAsync(existingCreatorPhoneNumber);
			Assert.IsTrue(result);
		}

		[Test]
		public async Task CreatorExistByPhoneNumberAsyncShouldRetturnFalseWhenNotExists()
		{
			string notExistingCreatorPhoneNumber = User.PhoneNumber;
			bool result = await this.creatorService.CreatorExistByPhoneNumberAsync(notExistingCreatorPhoneNumber);
			Assert.IsFalse(result);
		}

		[Test]
		public async Task CreateShouldCreateNewCreator()
		{
			
			string userId = User.Id.ToString();
			var model = new BecomeCreatorFormModel
			{
				PhoneNumber = "1234567890"
			};


			await creatorService.Create(userId, model);


			var createdCreator = await dbContext.Creators.FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
			Assert.IsNotNull(createdCreator);
			Assert.AreEqual(model.PhoneNumber, createdCreator.PhoneNumber);

			var updatedUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
			Assert.AreEqual(model.PhoneNumber, updatedUser.PhoneNumber);
		}

		[Test]
		public async Task GetCreatorIdByUserIdAsync_ShouldReturnCreatorId()
		{
			var existingUserId = CreatorUser.Id.ToString();

			var creatorId = await creatorService.GetCreatorIdByUserIdAsync(existingUserId);

			Assert.IsNotNull(creatorId);
		}

		[Test]
		public async Task GetCreatorIdByUserIdAsync_ShouldReturnNullWhenNotExists()
		{
			var existingUserId = User.Id.ToString();

			var creatorId = await creatorService.GetCreatorIdByUserIdAsync(existingUserId);

			Assert.IsNull(creatorId);
		}

	}
}