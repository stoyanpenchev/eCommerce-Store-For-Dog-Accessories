namespace PawAndCollar.Data.Models.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.BuyedProducts = new List<Product>();
            this.Id = Guid.NewGuid();
        }

        public ICollection<Product> BuyedProducts { get; set; }

    }
}
