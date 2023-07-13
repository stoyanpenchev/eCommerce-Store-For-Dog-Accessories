using PawAndCollar.Data;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class ApplicationUserService : IApplicationUserService
	{
		private readonly PawAndCollarDbContext dbContext;
		public ApplicationUserService(PawAndCollarDbContext dbContext)
		{
			this.dbContext = dbContext;
		}


	}
}
