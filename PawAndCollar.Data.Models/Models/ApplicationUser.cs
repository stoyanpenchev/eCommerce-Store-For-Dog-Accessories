namespace PawAndCollar.Data.Models.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.BuyedProducts = new List<Product>();
            this.Reviews = new List<Review>();
            this.Orders = new List<Order>();
            this.Id = Guid.NewGuid();
        }

        [ForeignKey(nameof(ActiveCart))]
		public Guid? CartId { get; set; }
		public Cart ActiveCart { get; set; }
        public ICollection<Product> BuyedProducts { get; set; } = null!;
        public int MyProperty { get; set; }
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<Order> Orders { get; set; }

    }
}
