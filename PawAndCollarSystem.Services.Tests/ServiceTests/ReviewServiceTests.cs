using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollarServices.Interfaces;
using PawAndCollarServices;
using System.Threading.Tasks;
using System;
using PawAndCollarSystem.Services.Tests.CreatorTests;
using PawAndCollar.Web.ViewModels.Review;

namespace PawAndCollarSystem.Services.Tests.ServiceTests
{
	using static DatabaseSeeder;
	public class ReviewServiceTests
	{
		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private IOrderService orderService;
		private IReviewService reviewService;

		[SetUp]
		public async Task OneTimeSetup()
		{
			this.dbOptions = new DbContextOptionsBuilder<PawAndCollarDbContext>()
				.UseInMemoryDatabase("PawAndCollarInMemory" + Guid.NewGuid().ToString())
				.Options;
			dbContext = new PawAndCollarDbContext(this.dbOptions, false);

			await dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.Database.EnsureCreatedAsync();
			SeedDatabase(dbContext);

			this.orderService = new OrderService(this.dbContext);
			this.reviewService = new ReviewService(this.dbContext, this.orderService);
		}

		[Test]
		public async Task GetReviewByCommentIdAsync_ShouldGetReviewByComentId()
		{
			int commentId = CommentCollar.Id;
			ReviewViewModel review = await this.reviewService.GetReviewByCommentIdAsync(commentId);

			Assert.AreEqual(ReviewCollar.Id, review.Id);
			Assert.AreEqual(ReviewCollar.AverageScore, review.AverageRating);
			Assert.AreEqual(ProductCollar.Id, review.Product.Id);
		}

		[Test]
		public async Task GetReviewByCommentIdAsync_ShouldReturnNullIfCommentIdIsInvalid()
		{
			int commentId = 99;
			ReviewViewModel review = await this.reviewService.GetReviewByCommentIdAsync(commentId);

			Assert.IsNull(review);
		}

		[Test]
		public async Task GetReviewByIdAsync_ShouldGetReviewById()
		{
			string userId = User.Id.ToString();
			int reviewId = ReviewCollar.Id;
			ReviewViewModel review = await this.reviewService.GetReviewByIdAsync(userId, reviewId);

			Assert.AreEqual(ReviewCollar.Id, review.Id);
			Assert.AreEqual(ReviewCollar.AverageScore, review.AverageRating);
			Assert.AreEqual(ProductCollar.Id, review.Product.Id);
		}

		[Test]
		public async Task GetReviewByIdAsync_ShouldReturnNullIfReviewIdIsInvalid()
		{
			string userId = User.Id.ToString();
			int reviewId = 99;
			ReviewViewModel review = await this.reviewService.GetReviewByIdAsync(userId, reviewId);

			Assert.IsNull(review);
		}

		[Test]
		public async Task GetReviewByProductIdAsync_ShouldReturnReviewByProductId()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;
			string sorting = string.Empty;
			ProductCollar.ReviewId = ReviewCollar.Id;
			await this.dbContext.SaveChangesAsync();
			int commentRating = (int)CommentCollar.RatingType;

			ReviewViewModel review = await this.reviewService.GetReviewByProductIdAsync(productId, userId, sorting);

			Assert.AreEqual(ReviewCollar.Id, review.Id);
			Assert.AreEqual(commentRating, review.AverageRating);
			Assert.AreEqual(ProductCollar.Id, review.Product.Id);
		}

		[Test]
		public async Task GetReviewByProductIdAsync_ShouldReturnNullIfproductIsInvalid()
		{
			string userId = User.Id.ToString();
			int productId = 99;
			string sorting = string.Empty;
			ProductCollar.ReviewId = ReviewCollar.Id;
			await this.dbContext.SaveChangesAsync();

			ReviewViewModel review = await this.reviewService.GetReviewByProductIdAsync(productId, userId, sorting);

			Assert.IsNull(review);
		}


	}
}
