using PawAndCollar.Web.ViewModels.Comment;
using PawAndCollar.Web.ViewModels.Product;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Review
{
	public class ReviewViewModel
	{
        public ReviewViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }

        [Key]
        public int Id { get; set; }
        public double AverageRating { get; set; }

        [Required]
        public ProductReviewViewModel Product { get; set; } = null!;

        public bool IsCustomerPurchasedProduct { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

    }
}
