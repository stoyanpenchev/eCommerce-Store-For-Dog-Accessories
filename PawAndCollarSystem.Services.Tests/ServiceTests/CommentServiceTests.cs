using PawAndCollarSystem.Services.Tests.CreatorTests;

namespace PawAndCollarSystem.Services.Tests.ServiceTests
{
	using Microsoft.EntityFrameworkCore;
	using PawAndCollar.Data;
	using PawAndCollarServices.Interfaces;
	using PawAndCollarServices;
	using System.Threading.Tasks;
	using System;
	using static DatabaseSeeder;
	using PawAndCollar.Web.ViewModels.Comment;

	public class CommentServiceTests
	{
		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private ICommentService commentService;

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

			this.commentService = new CommentService(this.dbContext);
		}

		[Test]
		public async Task CreateCommentAync_ShouldCreateComment()
		{
			string userId = User.Id.ToString();
			CommentCreateViewModel comment = new CommentCreateViewModel()
			{
				Content = "Test comment",
				DatePosted = DateTime.UtcNow.ToString(),
				ReviewId = 1,
				RatingType = 1,
				AuthorName = User.UserName
			};

			await this.commentService.CreateCommentAync(comment, userId);

			Assert.AreEqual(2, this.dbContext.Comments.CountAsync().Result);

		}

		[Test]
		public async Task DeleteCommentAsync_ShouldDeleteComment()
		{
			CommentViewModel comment = new CommentViewModel()
			{
				Id = 1,
				Content = "Test comment",
				DatePosted = DateTime.UtcNow.ToString(),
				RatingType = 1,
				AuthorName = User.UserName
			};

			await this.commentService.DeleteCommentAsync(comment);

			Assert.AreEqual(0, this.dbContext.Comments.CountAsync().Result);
		}

		[Test]
		public async Task DeleteCommentAsync_ShouldNotDeleteCommentIfCommentIsInvalid()
		{
			CommentViewModel comment = new CommentViewModel()
			{
				Id = 2,
				Content = "Test comment",
				DatePosted = DateTime.UtcNow.ToString(),
				RatingType = 1,
				AuthorName = User.UserName
			};

			await this.commentService.DeleteCommentAsync(comment);

			Assert.AreEqual(1, this.dbContext.Comments.CountAsync().Result);
		}

		[Test]
		public async Task EditCommentAsync_ShouldEditComment()
		{
			CommentViewModel comment = new CommentViewModel()
			{
				Id = 1,
				Content = "Test comment",
				DatePosted = DateTime.UtcNow.ToString(),
				RatingType = 1,
				AuthorName = User.UserName
			};

			await this.commentService.EditCommentAsync(comment);
			int rating = (int)CommentCollar.RatingType;

			Assert.AreEqual(1, rating);
			Assert.AreEqual("Test comment", CommentCollar.Content);
		}

		[Test]
		public async Task EditCommentAsync_ShouldNotEditCommentIfTheCommentIsInvalid()
		{
			CommentViewModel comment = new CommentViewModel()
			{
				Id = 54,
				Content = "Test comment",
				DatePosted = DateTime.UtcNow.ToString(),
				RatingType = 1,
				AuthorName = User.UserName
			};

			await this.commentService.EditCommentAsync(comment);
			int rating = (int)CommentCollar.RatingType;

			Assert.AreNotEqual(1, rating);
			Assert.AreNotEqual("Test comment", CommentCollar.Content);
		}

		[Test]
		public async Task GetCommentByIdAsync_ShouldGetCommentById()
		{
			

			CommentViewModel commentFromDb = await this.commentService.GetCommentByIdAsync(CommentCollar.Id);

			Assert.AreEqual(CommentCollar.Id, commentFromDb.Id);
			Assert.AreEqual(CommentCollar.Content, commentFromDb.Content);
			Assert.AreEqual((int)CommentCollar.RatingType, commentFromDb.RatingType);
			Assert.AreEqual(CommentCollar.Customer.UserName, commentFromDb.AuthorName);
		}

		[Test]
		public async Task GetCommentByIdAsync_ShouldReturnNullWhenCommentIdIsInvalid()
		{

			CommentViewModel commentFromDb = await this.commentService.GetCommentByIdAsync(45);

			Assert.IsNull(commentFromDb);
		}

		[Test]
		public async Task IsCommentBelongToUser_ShouldReturnTrueIfCommentBelongsToUser()
		{
			string userId = User.Id.ToString();

			bool isCommentBelongToUser = await this.commentService.IsCommentBelongToUser(userId, CommentCollar.Id);

			Assert.IsTrue(isCommentBelongToUser);
		}

		[Test]
		public async Task IsCommentBelongToUser_ShouldReturnFalseIfCommentDoesNotBelongToUser()
		{
			string userId = User.Id.ToString();

			bool isCommentBelongToUser = await this.commentService.IsCommentBelongToUser(userId, 45);

			Assert.IsFalse(isCommentBelongToUser);
		}

		[Test]
		public async Task IsCommentExistByIdAsync_ShouldReturnTrueIfCommentExists()
		{
			bool isCommentExist = await this.commentService.IsCommentExistByIdAsync(CommentCollar.Id);

			Assert.IsTrue(isCommentExist);
		}

		[Test]
		public async Task IsCommentExistByIdAsync_ShouldReturnFalseIfCommentDoesNotExist()
		{
			bool isCommentExist = await this.commentService.IsCommentExistByIdAsync(45);

			Assert.IsFalse(isCommentExist);
		}
	}
}
