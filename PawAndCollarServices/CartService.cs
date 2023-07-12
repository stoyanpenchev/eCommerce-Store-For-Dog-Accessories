using PawAndCollar.Data;
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

	}
}
