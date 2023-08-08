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

		public async Task<ReviewViewModel> GetReviewByCommentIdAsync(int id)
		{
			Review? review = await this.dbContext.Reviews
				.Include(r => r.Product)
				.Include(r => r.Comments)
				.ThenInclude(c => c.Customer)
				.Where(r => r.Comments.Any(c => c.Id == id))
				.FirstOrDefaultAsync();

			if(review == null)
			{
				  return null;
			}
			ReviewViewModel reviewModel = new ReviewViewModel()
			{
				Id = review.Id,
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
				}).ToList()
			};
			return reviewModel;
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

		public async Task<ReviewViewModel> GetReviewByProductIdAsync(int productId, string userId, string sorting)
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

            double averageRating = 0.0;

            if (product.Review?.Comments?.Any() == true)
            {
                int totalRating = product.Review.Comments.Sum(c => (int)c.RatingType);
                int numberOfComments = product.Review.Comments.Count();

                averageRating = (double)totalRating / numberOfComments;
                averageRating = Math.Round(averageRating, 1);
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

                int totalRating = product.Review.Comments.Sum(c => (int)c.RatingType);
                int numberOfComments = product.Review.Comments.Count();

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
					ImageUrl = product.ImageUrl,
					AverageReviewScore = product.Review != null ? product.Review.AverageScore : 0
				},
				IsCustomerPurchasedProduct = false,
				AverageRating = averageRating,
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
            if (!string.IsNullOrEmpty(sorting))
            {
                switch (sorting)
                {
                    case "Newest":
                        reviewViewModel.Comments = reviewViewModel.Comments.OrderByDescending(c => c.DatePosted).ToList();
                        break;
                    case "Oldest":
                        reviewViewModel.Comments = reviewViewModel.Comments.OrderBy(c => c.DatePosted).ToList();
                        break;
                    case "HighestRating":
                        reviewViewModel.Comments = reviewViewModel.Comments.OrderByDescending(c => c.RatingType).ToList();
                        break;
                    case "LowestRating":
                        reviewViewModel.Comments = reviewViewModel.Comments.OrderBy(c => c.RatingType).ToList();
                        break;
                }
            }

            return reviewViewModel;
		}


	}
}
