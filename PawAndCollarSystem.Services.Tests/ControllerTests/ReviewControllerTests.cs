using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PawAndCollar.Web.Controllers;
using PawAndCollar.Web.ViewModels.Review;
using PawAndCollarServices.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	[TestFixture]
	public class ReviewControllerTests
	{
		private Mock<IReviewService> _reviewServiceMock;
		private Mock<IProductService> _productServiceMock;
		private ReviewController _controller;

		[SetUp]
		public void Setup()
		{
			_reviewServiceMock = new Mock<IReviewService>();
			_productServiceMock = new Mock<IProductService>();

			_controller = new ReviewController(_reviewServiceMock.Object, _productServiceMock.Object);
			_controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
		}

		[Test]
		public async Task ReviewIndex_ProductExists_ReturnsViewResult()
		{
			int productId = 1;
			string sorting = "DateDescending";
			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
	{
		new Claim(ClaimTypes.NameIdentifier, "user123")
    }));
			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = user }
			};

			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(true);
			_reviewServiceMock.Setup(r => r.GetReviewByProductIdAsync(productId, It.IsAny<string>(), sorting))
							 .ReturnsAsync(new ReviewViewModel());

			var result = await _controller.ReviewIndex(productId, sorting);

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.IsInstanceOf<ReviewViewModel>(viewResult.Model);
		}

		[Test]
		public async Task ReviewIndex_ProductDoesNotExist_RedirectsToHomeIndex()
		{
			// Arrange
			int productId = 1;
			string sorting = "DateDescending";

			// Set up a mock ClaimsPrincipal with a user identity
			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
		new Claim(ClaimTypes.NameIdentifier, "user123") // Replace "user123" with the actual user ID
			}));
			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = user }
			};

			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(false);

			// Act
			var result = await _controller.ReviewIndex(productId, sorting);

			// Assert
			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectToAction = result as RedirectToActionResult;
			Assert.AreEqual("Index", redirectToAction.ActionName);
			Assert.AreEqual("Home", redirectToAction.ControllerName);

			// Verify TempData["ErrorMessage"] is set
			Assert.AreEqual("Product does not exist", _controller.TempData["ErrorMessage"]);
		}

	}

}
