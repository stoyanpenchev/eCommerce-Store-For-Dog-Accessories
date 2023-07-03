using PawAndCollar.Web.ViewModels.Creator;

namespace PawAndCollarServices.Interfaces
{
    public interface ICreatorService
    {
        Task AddProductAsync(AddProductViewModel model, string id);

        Task<bool> AgentExistByUserIdAsync(string userId);

        Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeCreatorFormModel model);
    }
}
