namespace PawAndCollar.Web.ViewModels.User
{
	public class ApplicationUserViewModel
	{
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;

        public bool? OpenOrders { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
