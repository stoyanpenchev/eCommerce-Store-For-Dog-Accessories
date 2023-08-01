using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Web.ViewModels.Comment;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollar.Web.ViewModels.Review;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class ReviewService : IReviewService
	{
		private readonly PawAndCollarDbContext dbContext;
		private readonly IOrderService orderService;
		public ReviewService(PawAndCollarDbContext dbContext, IOrderService orderService)
		{
			this.dbContext = dbContext;
			this.orderService = orderService;
		}

		public async Task<ReviewViewModel> GetReviewByIdAsync(string userId, int reviewId)
		{
			Review? review = await this.dbContext.Reviews
				.Include(r => r.Product)
				.Include(r => r.Comments)
				.ThenInclude(c => c.Customer)
				.Where(r => r.Id == reviewId)
				.FirstOrDefaultAsync();

			if(review == null)
			{
				return null;
			}
			bool isItBought = await this.orderService.UserPurchasedProductAsync(userId, review.ProductId);

			ReviewViewModel reviewModel = new ReviewViewModel()
			{
				Id = review.Id,
				IsCustomerPurchasedProduct = isItBought,
				AverageRating = review.AverageScore,
				Product = new ProductReviewViewModel()
				{
					Id = review.Product.Id,
					ProductName = review.Product.Name,
					Price = review.Product.Price,
					ImageUrl = review.Product.ImageUrl,
				},
				Comments = review.Comments.Select(c => new CommentViewModel()
				{
					Id = c.Id,
					Content = c.Content,
					AuthorName = c.Customer.UserName,
					RatingType = (int)c.RatingType,
					DatePosted = c.DatePosted.ToString()
				}).ToList() ?? new List<CommentViewModel>()
			};
			return reviewModel;
		}

		public async Task<ReviewViewModel> GetReviewByProductIdAsync(int productId, string userId)
		{
			Product? product = await this.dbContext.Products
				.Include(p => p.Review)
				.ThenInclude(r => r.Comments)
				.ThenInclude(c => c.Customer)
				.FirstOrDefaultAsync(p => p.Id == productId);

			if (product == null)
			{
				return null;
			}

			double averageRating = 0;
			if (product.Review?.Comments?.Any() == true)
			{
				averageRating = product.Review.Comments.Average(c => (int)c.RatingType);
			}

			if (product.Review == null)
			{
				Review newReview = new Review()
				{
					Product = product,
					AverageScore = averageRating,
				};
				await this.dbContext.Reviews.AddAsync(newReview);
				await this.dbContext.SaveChangesAsync();

				product.ReviewId = newReview.Id;
				await this.dbContext.SaveChangesAsync();
			}
			Review? productReview = await this.dbContext.Reviews
				.Include(r => r.Comments)
				.FirstOrDefaultAsync(r => r.Id == product.ReviewId);

			ReviewViewModel reviewViewModel = new ReviewViewModel()
			{
				Id = productReview.Id,
				Product = new ProductReviewViewModel()
				{
					Id = product.Id,
					ProductName = product.Name,
					Price = product.Price,
					ImageUrl = product.ImageUrl
				},
				IsCustomerPurchasedProduct = false,
				AverageRating = productReview.AverageScore,
				Comments = productReview.Comments.Select(c => new CommentViewModel()
				{
					Id = c.Id,
					Content = c.Content,
					AuthorName = c.Customer.UserName,
					RatingType = (int)c.RatingType,
					DatePosted = c.DatePosted.ToString()
				}).ToList() ?? new List<CommentViewModel>()
			};

			if (!string.IsNullOrEmpty(userId))
			{
				bool isCustomerPurchasedProduct = await this.orderService.UserPurchasedProductAsync(userId, productId);
				reviewViewModel.IsCustomerPurchasedProduct = isCustomerPurchasedProduct;
			}

			return reviewViewModel;
		}


	}
}
