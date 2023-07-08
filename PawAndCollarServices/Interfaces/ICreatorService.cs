using PawAndCollar.Web.ViewModels.Creator;

namespace PawAndCollarServices.Interfaces
{
    public interface ICreatorService
    {
        
        Task<bool> CreatorExistByUserIdAsync(string userId);

        Task<bool> CreatorExistByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeCreatorFormModel model);

        Task<string?> GetCreatorIdByUserIdAsync(string userId);

	}
}
