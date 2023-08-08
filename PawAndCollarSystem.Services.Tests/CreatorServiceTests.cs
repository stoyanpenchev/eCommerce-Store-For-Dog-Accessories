using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using System;

namespace PawAndCollarSystem.Services.Tests
{
	public class CreatorServiceTests
	{

		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

        public CreatorServiceTests()
        {
            
        }

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			this.dbOptions = new DbContextOptionsBuilder<PawAndCollarDbContext>()
				.UseInMemoryDatabase("PawAndCollarInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new PawAndCollarDbContext(this.dbOptions); 
		}

        [SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CreatorExistByUserIdAsyncShouldRetturnTrueWhenExists()
		{
			 
		}


	}
}