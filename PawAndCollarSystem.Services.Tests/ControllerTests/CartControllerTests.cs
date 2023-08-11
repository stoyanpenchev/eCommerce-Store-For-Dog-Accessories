using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PawAndCollar.Web.Controllers;
using PawAndCollar.Web.ViewModels.Cart;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	[TestFixture]
	public class CartControllerTests
	{
		private CartController _controller;
		private Mock<ICartService> _cartServiceMock;
		private Mock<ICreatorService> _creatorServiceMock;
		private Mock<IProductService> _productServiceMock;

		[SetUp]
		public void Setup()
		{
			_cartServiceMock = new Mock<ICartService>();
			_creatorServiceMock = new Mock<ICreatorService>();
			_productServiceMock = new Mock<IProductService>();

			_controller = new CartController(
				_cartServiceMock.Object,
				_creatorServiceMock.Object,
				_productServiceMock.Object
			);
		}

		[Test]
		public async Task ViewCart_ReturnsViewWithCartItems()
		{
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

			var cartViewModel = new ViewCartViewModel
			{
				CartItems = new List<CartItemViewModel>
				{
					new CartItemViewModel { Id = 1, Quantity = 2 },
					new CartItemViewModel { Id = 2, Quantity = 3 }
				}
			};

			_cartServiceMock.Setup(s => s.GetCartItemsAsync(userId))
				.ReturnsAsync(cartViewModel);

			var result = await _controller.ViewCart() as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual(cartViewModel, result.Model);
		}

		[Test]
		public async Task AddToCart_ValidProduct_AddsToCartAndRedirectsToViewCart()
		{
			string userId = "user123";
			int productId = 1;

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

			var product = new AddProductViewModel
			{
				Id = productId,
				Quantity = 10
			};

			var cartItems = new ViewCartViewModel
			{
				CartItems = new List<CartItemViewModel>
				{
					new CartItemViewModel { Id = productId, Quantity = 5 },
                }
			};

			_productServiceMock.Setup(s => s.ExistsByIdAsync(productId))
				.ReturnsAsync(true);

			_productServiceMock.Setup(s => s.GetProductByIdAsync(productId))
				.ReturnsAsync(product);

			_cartServiceMock.Setup(s => s.GetCartItemsAsync(userId))
				.ReturnsAsync(cartItems);

			var result = await _controller.AddToCart(productId) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("ViewCart", result.ActionName);
		}

		[Test]
		public async Task AddToCart_ProductDoesNotExist_RedirectsToIndexWithErrorMessage()
		{
			string userId = "user123";
			int productId = 1;

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

			_productServiceMock.Setup(s => s.ExistsByIdAsync(productId))
				.ReturnsAsync(false);

			_controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());

			var result = await _controller.AddToCart(productId) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
			Assert.AreEqual("Product does not exist", _controller.TempData["ErrorMessage"]);
		}

	}
}
