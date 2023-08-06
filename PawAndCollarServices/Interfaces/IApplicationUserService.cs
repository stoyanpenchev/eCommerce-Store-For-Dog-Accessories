using PawAndCollar.Web.ViewModels.User;

namespace PawAndCollarServices.Interfaces
{
    public interface IApplicationUserService
    {
        Task<IEnumerable<ApplicationUserViewModel>> AllAsync();

        Task<ApplicationUserViewModel> GetUserByIdAsync(Guid id);

        Task<bool?> IsItHaveOpenOrders(string userId);

        Task DeleteUserAsync(Guid id);
    }
}
