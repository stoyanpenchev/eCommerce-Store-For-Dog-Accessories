using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PawAndCollar.Web.Controllers;
using PawAndCollar.Web.ViewModels.Comment;
using PawAndCollar.Web.ViewModels.Review;
using PawAndCollarServices.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	using static PawAndCollar.Common.NotificationMessagesConstants;

	[TestFixture]
	public class CommentControllerTests
	{
		private Mock<IReviewService> _reviewServiceMock;
		private Mock<IEnumService> _enumServiceMock;
		private Mock<ICommentService> _commentServiceMock;
		private CommentController _controller;

		[SetUp]
		public void Setup()
		{
			_reviewServiceMock = new Mock<IReviewService>();
			_enumServiceMock = new Mock<IEnumService>();
			_commentServiceMock = new Mock<ICommentService>();

			_controller = new CommentController(_reviewServiceMock.Object, _enumServiceMock.Object, _commentServiceMock.Object);

			_controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
		}

		[Test]
		public async Task Create_Get_ValidReviewId_ReturnsView()
		{
			int reviewId = 1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
					new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByIdAsync(userId, reviewId))
				.ReturnsAsync(new ReviewViewModel
				{
					Id = 2,
					IsCustomerPurchasedProduct = true,
					Product = new PawAndCollar.Web.ViewModels.Product.ProductReviewViewModel
                    {
						Id = 1,
						ProductName = "Test Product",
						ImageUrl = "https://test.com/test.jpg",
						Price = 10.00M,
						AverageReviewScore = 4.5
					},
					AverageRating = 4.5,
					Comments = new List<CommentViewModel>()
				});

			var result = await _controller.Create(reviewId) as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual(typeof(CommentCreateViewModel), result.Model.GetType());
		}


		[Test]
		public async Task Create_Get_ReviewIdIsNull_ReturnsRedirectToActionIndex()
		{
			int reviewId = -1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			var result = await _controller.Create(reviewId) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("Review does not exist", _controller.TempData[ErrorMessage]);
		}

		[Test]
		public async Task Create_Get_ReviewNotFound_ReturnsRedirectToActionIndex()
		{
			// Arrange
			int reviewId = 1;
			string userId = "user123"; // Set the user ID here

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByIdAsync(userId, reviewId))
				.ReturnsAsync((ReviewViewModel)null);

			// Act
			var result = await _controller.Create(reviewId) as RedirectToActionResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("Review does not exist", _controller.TempData[ErrorMessage]);
		}

		[Test]
		public async Task Create_Get_ProductNotPurchased_ReturnsRedirectToActionIndex()
		{
			// Arrange
			int reviewId = 1;
			string userId = "user123"; // Set the user ID here

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByIdAsync(userId, reviewId))
				.ReturnsAsync(new ReviewViewModel
				{
					IsCustomerPurchasedProduct = false // Set other properties as needed
				});

			// Act
			var result = await _controller.Create(reviewId) as RedirectToActionResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("You must purchase the product to comment", _controller.TempData[ErrorMessage]);
		}

		[Test]
		public async Task Create_Post_ReviewNotFound_ReturnsRedirectToActionIndex()
		{
			int reviewId = 1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			CommentCreateViewModel validCommentModel = new CommentCreateViewModel
			{
				ReviewId = reviewId,
				Content = "A valid comment",
				RatingType = (int)RatingTypes.FiveStars
			};

			_reviewServiceMock.Setup(s => s.GetReviewByIdAsync(userId, reviewId))
				.ReturnsAsync((ReviewViewModel)null);

			var result = await _controller.Create(validCommentModel) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("Review does not exist", _controller.TempData[ErrorMessage]);
		}

		[Test]
		public async Task Create_Post_ValidModel_ReturnsRedirectToActionReviewIndex()
		{
			int reviewId = 1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			CommentCreateViewModel validCommentModel = new CommentCreateViewModel
			{
				ReviewId = reviewId,
				Content = "A valid comment",
				RatingType = (int)RatingTypes.FiveStars 
			};

			ReviewViewModel mockReview = new ReviewViewModel
			{
				IsCustomerPurchasedProduct = true,
				Product = new ProductReviewViewModel
				{
					Id = 42
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByIdAsync(userId, reviewId))
				.ReturnsAsync(mockReview);

			var result = await _controller.Create(validCommentModel) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("ReviewIndex", result.ActionName);
			Assert.AreEqual("Review", result.ControllerName);
			Assert.AreEqual(mockReview.Product.Id, result.RouteValues["id"]);

			Assert.AreEqual("Comment created successfully!", _controller.TempData[SuccessMessage]);
		}


		[Test]
		public async Task Edit_ValidModel_CommentDoesNotExist_ReturnsRedirectToActionIndex()
		{
			int commentId = 1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			CommentViewModel validCommentModel = new CommentViewModel
			{
				Id = commentId,
				Content = "Updated comment",
				RatingType = (int)RatingTypes.FourStars
			};

			ReviewViewModel mockReview = new ReviewViewModel
			{
				Product = new ProductReviewViewModel
				{
					Id = 42
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByCommentIdAsync(commentId))
				.ReturnsAsync(mockReview);

			_commentServiceMock.Setup(s => s.IsCommentBelongToUser(userId, commentId))
				.ReturnsAsync(true);

			_commentServiceMock.Setup(s => s.IsCommentExistByIdAsync(commentId))
				.ReturnsAsync(false);

			var result = await _controller.Edit(validCommentModel) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("Comment does not exist", _controller.TempData[ErrorMessage]);
		}

		[Test]
		public async Task Edit_ValidModel_CommentNotBelongToUser_ReturnsRedirectToActionIndex()
		{
			int commentId = 1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			CommentViewModel validCommentModel = new CommentViewModel
			{
				Id = commentId,
				Content = "Updated comment",
				RatingType = (int)RatingTypes.FourStars
			};

			ReviewViewModel mockReview = new ReviewViewModel
			{
				Product = new ProductReviewViewModel
				{
					Id = 42
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByCommentIdAsync(commentId))
				.ReturnsAsync(mockReview);

			_commentServiceMock.Setup(s => s.IsCommentBelongToUser(userId, commentId))
				.ReturnsAsync(false);

			var result = await _controller.Edit(validCommentModel) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
		}

		[Test]
		public async Task Delete_CommentDoesNotExist_ReturnsRedirectToActionIndex()
		{
			int commentId = 1;
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_reviewServiceMock.Setup(s => s.GetReviewByCommentIdAsync(commentId))
				.ReturnsAsync(new ReviewViewModel());

			_commentServiceMock.Setup(s => s.IsCommentBelongToUser(userId, commentId))
				.ReturnsAsync(true);

			_commentServiceMock.Setup(s => s.IsCommentExistByIdAsync(commentId))
				.ReturnsAsync(false);

			var result = await _controller.Delete(commentId) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("Comment does not exist", _controller.TempData[ErrorMessage]);
		}
	}

}
