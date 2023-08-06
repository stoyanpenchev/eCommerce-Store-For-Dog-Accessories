namespace PawAndCollar.Web.ViewModels.Review
{
	using PawAndCollar.Web.ViewModels.Comment;
	using PawAndCollar.Web.ViewModels.Product;
	using PawAndCollar.Web.ViewModels.Review.Enums;
	using System.ComponentModel.DataAnnotations;

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

		[Display(Name = "Sort Products By")]
		public ReviewSorting? ReviewSorting { get; set; }

		public ICollection<CommentViewModel> Comments { get; set; }

	}
}
