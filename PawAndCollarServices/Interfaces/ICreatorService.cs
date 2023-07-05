using PawAndCollar.Web.ViewModels.Creator;

namespace PawAndCollarServices.Interfaces
{
    public interface ICreatorService
    {
        
        Task<bool> AgentExistByUserIdAsync(string userId);

        Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeCreatorFormModel model);

        Task<string?> GetCreatorIdByUserIdAsync(string userId);

	}
}
