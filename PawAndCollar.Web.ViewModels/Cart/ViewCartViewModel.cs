namespace PawAndCollar.Web.ViewModels.Cart
{
	public class ViewCartViewModel
	{
        public ViewCartViewModel()
        {
            this.CartItems = new List<CartItemViewModel>();
        }
        public ICollection<CartItemViewModel> CartItems { get; set; }
    }
}
