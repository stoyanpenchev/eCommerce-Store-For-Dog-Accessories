using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.Controllers;
using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	using static PawAndCollar.Common.NotificationMessagesConstants;
	[TestFixture]
	public class ProductControllerTests
	{
		private ProductController _controller;
		private Mock<IProductService> _productServiceMock;
		private Mock<ICategoryService> _categoryServiceMock;
		private Mock<IEnumService> _enumServiceMock;
		private Mock<ISizeService> _sizeServiceMock;
		private Mock<ICreatorService> _creatorServiceMock;
		private Mock<ITempDataDictionary> _tempDataMock;

		[SetUp]
		public void SetUp()
		{
			_productServiceMock = new Mock<IProductService>();
			_categoryServiceMock = new Mock<ICategoryService>();
			_enumServiceMock = new Mock<IEnumService>();
			_sizeServiceMock = new Mock<ISizeService>();
			_creatorServiceMock = new Mock<ICreatorService>();
			_tempDataMock = new Mock<ITempDataDictionary>();

			var httpContext = new DefaultHttpContext();
			httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
		}));

			var controllerContext = new ControllerContext
			{
				HttpContext = httpContext
			};

			_controller = new ProductController(
				_productServiceMock.Object,
				_categoryServiceMock.Object,
				_enumServiceMock.Object,
				_sizeServiceMock.Object,
				_creatorServiceMock.Object
			)
			{
				ControllerContext = controllerContext,
				TempData = _tempDataMock.Object
			};
		}

		[Test]
		public async Task All_ReturnsViewWithCorrectModel()
		{

			var queryModel = new AllProductsQueryModel();
			var products = new List<ProductHomeViewModel>
	{
		new ProductHomeViewModel { Id = 1, Name = "Product 1" },
		new ProductHomeViewModel { Id = 2, Name = "Product 2" }
	};
			_productServiceMock.Setup(p => p.GetAllProductsAsync(queryModel)).ReturnsAsync(new AllProductsFilteredAndPagedServiceModel
			{
				Products = products,
				TotalProductsCount = products.Count
			});


			var result = await _controller.All(queryModel) as ViewResult;
			var model = result?.Model as AllProductsQueryModel;


			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual(products.Count, model.Products.Count());
			Assert.AreEqual(products.Count, model.TotalProducts);
		}

		[Test]
		public async Task Search_Post_ValidModel_RedirectsToDisplaySearchResults()
		{

			var model = new SearchProductByNameViewModel { SearchedItem = "Product" };
			var products = new List<ProductHomeViewModel>
	{
		new ProductHomeViewModel { Id = 1, Name = "Product 1" },
		new ProductHomeViewModel { Id = 2, Name = "Product 2" }
	};
			_productServiceMock.Setup(p => p.SearchProductsByNameAsync(model.SearchedItem)).ReturnsAsync(products);

			var result = await _controller.Search(model) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("DisplaySearchResults", result.ActionName);
			Assert.AreEqual(model.SearchedItem, result.RouteValues["searchedItem"]);
		}

		[Test]
		public async Task DisplaySearchResults_ReturnsViewWithCorrectModel()
		{

			var searchedItem = "Product";
			var products = new List<ProductHomeViewModel>
	{
		new ProductHomeViewModel { Id = 1, Name = "Product 1" },
		new ProductHomeViewModel { Id = 2, Name = "Product 2" }
	};
			_productServiceMock.Setup(p => p.SearchProductsByNameAsync(searchedItem)).ReturnsAsync(products);

			var result = await _controller.DisplaySearchResults(searchedItem) as ViewResult;
			var model = result?.Model as SearchProductByNameViewModel;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual(searchedItem, model.SearchedItem);
			Assert.AreEqual(products.Count, model.SearchResults.Count);
		}

		[TestCase(true)]
		[TestCase(false)]
		public async Task Mine_UserIsNotCreator_RedirectsToBecomeCreator(bool isCreatorValue)
		{
			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(false);

			_tempDataMock.SetupSet(tempData => tempData[ErrorMessage] = It.IsAny<string>());

			var httpContext = new DefaultHttpContext();
			httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
	{
		new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
	}));

			var controllerContext = new ControllerContext
			{
				HttpContext = httpContext
			};
			_controller.ControllerContext = controllerContext;

			var result = await _controller.Mine();

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectResult = result as RedirectToActionResult;
			Assert.AreEqual("Creator", redirectResult.ControllerName);
			Assert.AreEqual("Become", redirectResult.ActionName);

			// Verify TempData was set
			_tempDataMock.VerifySet(tempData => tempData[ErrorMessage] = "You are not a creator!", Times.Once);
		}

		[Test]
		public async Task Mine_UserIsCreator_ReturnsViewWithModel()
		{
			var products = new List<ProductHomeViewModel>
	{
		new ProductHomeViewModel { Id = 1, Name = "Product 1" },
		new ProductHomeViewModel { Id = 2, Name = "Product 2" }
	};

			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);
			_creatorServiceMock.Setup(c => c.GetCreatorIdByUserIdAsync(It.IsAny<string>())).ReturnsAsync(Guid.NewGuid().ToString());
			_productServiceMock.Setup(p => p.GetAllProductsByCreatorIdAsync(It.IsAny<string>())).ReturnsAsync(products);

			var httpContext = new DefaultHttpContext();
			httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
	{
		new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
	}));

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = httpContext
			};

			var result = await _controller.Mine() as ViewResult;
			var model = result?.Model as ICollection<ProductHomeViewModel>;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual(products.Count, model.Count);
		}

		[Test]
		public async Task Details_ProductExists_ReturnsViewWithModel()
		{

			int productId = 1;
			var productModel = new ProductDeatailsViewModel { Id = productId, Name = "Product 1" };
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(true);
			_productServiceMock.Setup(p => p.GetDetailsByIdAsync(productId)).ReturnsAsync(productModel);

			var result = await _controller.Details(productId) as ViewResult;
			var model = result?.Model as ProductDeatailsViewModel;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual(productId, model.Id);
		}

		[Test]
		public async Task Details_ProductDoesNotExist_RedirectsToHomeIndex()
		{
			// Arrange
			int productId = 1;
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(false);

			// Act
			var result = await _controller.Details(productId) as RedirectToActionResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
		}

		[Test]
		public async Task Add_GET_UserIsNotCreator_RedirectsToBecomeCreator()
		{
			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(false);

			_tempDataMock.SetupSet(tempData => tempData[ErrorMessage] = It.IsAny<string>());

			var httpContext = new DefaultHttpContext();
			httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
	{
		new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
	}));

			var controllerContext = new ControllerContext
			{
				HttpContext = httpContext
			};
			_controller.ControllerContext = controllerContext;

			var result = await _controller.Add();

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectResult = result as RedirectToActionResult;
			Assert.AreEqual("Creator", redirectResult.ControllerName);
			Assert.AreEqual("Become", redirectResult.ActionName);

			_tempDataMock.VerifySet(tempData => tempData[ErrorMessage] = "You are not a creator!", Times.Once);
		}

		[Test]
		public async Task Add_GET_UserIsCreator_ReturnsViewWithModel()
		{
			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);

			var categories = new List<AllCategoriesViewModel>
	{
		new AllCategoriesViewModel { Id = 1, Name = "Category 1" },
		new AllCategoriesViewModel { Id = 2, Name = "Category 2" }
	};
			var sizeList = new SelectList(new List<SelectListItem>());

			_categoryServiceMock.Setup(c => c.GetAllCategoriesAsync()).ReturnsAsync(categories);
			_enumServiceMock.Setup(e => e.GetEnumSelectList<SizeTypes>()).Returns(sizeList);

			var result = await _controller.Add();

			if (result is ViewResult viewResult)
			{
				var model = viewResult.Model as AddProductViewModel;

				Assert.IsNotNull(viewResult);
				Assert.IsNotNull(model);
				Assert.AreEqual(categories.Count, model.Categories.Count);
				Assert.AreSame(sizeList, model.SizeList);
			}
			else if (result is RedirectToActionResult redirectResult)
			{
				Assert.AreEqual("Creator", redirectResult.ControllerName);
				Assert.AreEqual("Become", redirectResult.ActionName);
			}
			else
			{
				Assert.Fail("Unexpected result type");
			}
		}

		[Test]
		public async Task Search_GET_ReturnsViewWithModel()
		{
			var result = await _controller.Search() as ViewResult;
			var model = result?.Model as SearchProductByNameViewModel;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
		}

		[Test]
		public async Task Search_POST_ValidModel_RedirectsToDisplaySearchResults()
		{
			var model = new SearchProductByNameViewModel { SearchedItem = "Item" };
			var products = new List<ProductHomeViewModel>
	{
		new ProductHomeViewModel { Id = 1, Name = "Product 1" },
		new ProductHomeViewModel { Id = 2, Name = "Product 2" }
	};
			_productServiceMock.Setup(p => p.SearchProductsByNameAsync(model.SearchedItem)).ReturnsAsync(products);

			var result = await _controller.Search(model) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("DisplaySearchResults", result.ActionName);
			Assert.AreEqual(model.SearchedItem, result.RouteValues["searchedItem"]);
		}
		[Test]
		public async Task Add_UserIsCreator_ModelIsValid_RedirectsToProductMine()
		{
			var model = new AddProductViewModel();
			var creatorId = Guid.NewGuid().ToString();

			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);
			_creatorServiceMock.Setup(c => c.GetCreatorIdByUserIdAsync(It.IsAny<string>())).ReturnsAsync(creatorId);
			_categoryServiceMock.Setup(c => c.ExistByIdAsync(It.IsAny<int>())).ReturnsAsync(true);

			var result = await _controller.Add(model);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectResult = result as RedirectToActionResult;
			Assert.AreEqual("Mine", redirectResult.ControllerName); 
			Assert.AreEqual("Product", redirectResult.ActionName);
		}

		[Test]
		public async Task Add_CategoryDoesNotExist_ReturnsViewWithError()
		{
			var model = new AddProductViewModel();
			var creatorId = Guid.NewGuid().ToString();

			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);
			_creatorServiceMock.Setup(c => c.GetCreatorIdByUserIdAsync(It.IsAny<string>())).ReturnsAsync(creatorId);
			_categoryServiceMock.Setup(c => c.ExistByIdAsync(It.IsAny<int>())).ReturnsAsync(false);

			var result = await _controller.Add(model);

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
			Assert.AreEqual("Category does not exist", viewResult.ViewData.ModelState[nameof(model.CategoryId)].Errors[0].ErrorMessage);
		}


		[Test]
		public async Task Edit_ProductExists_ReturnsViewWithModel()
		{
			// Arrange
			int productId = 1;
			var productModel = new AddProductViewModel();
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(true);
			_productServiceMock.Setup(p => p.GetProductByIdAsync(productId)).ReturnsAsync(productModel);
			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);
			_productServiceMock.Setup(p => p.IsCreatorWithIdOwnerOfProducWithIdAsync(productId, It.IsAny<string>())).ReturnsAsync(true);

			// Act
			var result = await _controller.Edit(productId);

			// Assert
			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.AreSame(productModel, viewResult.Model);
		}

		[Test]
		public async Task Edit_ProductDoesNotExist_ReturnsRedirectToIndex()
		{
			int productId = 1;
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(false);

			var result = await _controller.Edit(productId);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectToActionResult = result as RedirectToActionResult;
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
			Assert.AreEqual("Home", redirectToActionResult.ControllerName);
		}

		[Test]
		public async Task Edit_Post_InvalidModel_ReturnsViewWithModel()
		{
			int productId = 1;
			var model = new AddProductViewModel { Id = productId };
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(true);
			_controller.ModelState.AddModelError("some key", "some error");

			var result = await _controller.Edit(productId, model);

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.AreSame(model, viewResult.Model);
		}

		[Test]
		public async Task Delete_ProductExists_ReturnsViewWithModel()
		{
			int productId = 1;
			var productModel = new ProductPreDeleteViewModel();
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(true);
			_productServiceMock.Setup(p => p.GetProductForDeleteByIdAsync(productId)).ReturnsAsync(productModel);
			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);
			_productServiceMock.Setup(p => p.IsCreatorWithIdOwnerOfProducWithIdAsync(productId, It.IsAny<string>())).ReturnsAsync(true);

			var result = await _controller.Delete(productId);

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.AreSame(productModel, viewResult.Model);
		}

		[Test]
		public async Task Delete_ProductDoesNotExist_ReturnsRedirectToIndex()
		{
			int productId = 1;
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(false);

			var result = await _controller.Delete(productId);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectToActionResult = result as RedirectToActionResult;
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
			Assert.AreEqual("Home", redirectToActionResult.ControllerName);
		}

		[Test]
		public async Task Delete_Post_ValidModel_ReturnsRedirectToAction()
		{
			// Arrange
			int productId = 1;
			var model = new ProductPreDeleteViewModel();
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(true);
			_creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);
			_productServiceMock.Setup(p => p.IsCreatorWithIdOwnerOfProducWithIdAsync(productId, It.IsAny<string>())).ReturnsAsync(true);

			// Act
			var result = await _controller.Delete(model, productId);

			// Assert
			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectToActionResult = result as RedirectToActionResult;
			Assert.AreEqual("Mine", redirectToActionResult.ActionName);
			Assert.AreEqual("Product", redirectToActionResult.ControllerName);
		}

		[Test]
		public async Task Delete_ProductDoesNotExist_ReturnsRedirectToIndexWithErrorMessage()
		{
			int productId = 1;
			_productServiceMock.Setup(p => p.ExistsByIdAsync(productId)).ReturnsAsync(false);

			var result = await _controller.Delete(productId);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectToActionResult = result as RedirectToActionResult;
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
			Assert.AreEqual("Home", redirectToActionResult.ControllerName);
		}

	}

}
