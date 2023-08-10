using Microsoft.AspNetCore.Mvc;
using Moq;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;
using System.Collections.Generic;
using PawAndCollar.Web.Controllers;

using System.Threading.Tasks;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	[TestFixture]
	public class HomeControllerTests
	{
		[Test]
		public async Task Index_ShouldReturnViewWithProducts()
		{
			var productServiceMock = new Mock<IProductService>();
			var products = new List<ProductHomeViewModel>();
			ProductHomeViewModel product1 = new ProductHomeViewModel()
			{
				Id = 1,
				Name = "Collar",
				CreatorName = "Creator",
				ImageUrl = "https://www.google.com",
				Price = 10,
				Quantity = 1,
				Size = "M",
				AverageReviewScore = 5
			};
			products.Add(product1);

			productServiceMock.Setup(service => service.GetHomePageProductsAsync())
				.ReturnsAsync(products);

			var controller = new HomeController(productServiceMock.Object);

			var result = await controller.Index();

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = (ViewResult)result;
			Assert.IsInstanceOf<ICollection<ProductHomeViewModel>>(viewResult.Model);
			var model = (ICollection<ProductHomeViewModel>)viewResult.Model;
			Assert.AreEqual(products.Count, model.Count);
		}

		[Test]
		public async Task Index_ShouldReturnViewWithNoProducts()
		{
			var productServiceMock = new Mock<IProductService>();
			productServiceMock.Setup(service => service.GetHomePageProductsAsync())
				.ReturnsAsync(new List<ProductHomeViewModel>());

			var controller = new HomeController(productServiceMock.Object);

			var result = await controller.Index();

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = (ViewResult)result;
			Assert.IsInstanceOf<ICollection<ProductHomeViewModel>>(viewResult.Model);
			var model = (ICollection<ProductHomeViewModel>)viewResult.Model;
			Assert.AreEqual(0, model.Count);
		}

		[Test]
		public void Error_ShouldReturnErrorViewFor400Or404()
		{

			var productServiceMock = new Mock<IProductService>();
			var controller = new HomeController(productServiceMock.Object);

			var result400 = controller.Error(400) as ViewResult;
			var result404 = controller.Error(404) as ViewResult;

			Assert.IsNotNull(result400);
			Assert.AreEqual("Error404", result400.ViewName);

			Assert.IsNotNull(result404);
			Assert.AreEqual("Error404", result404.ViewName);
		}

	}
}
