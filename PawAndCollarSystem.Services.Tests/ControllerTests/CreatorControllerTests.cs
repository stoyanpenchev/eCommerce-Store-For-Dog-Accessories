using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PawAndCollar.Web.Controllers;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollarServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	using static PawAndCollar.Common.NotificationMessagesConstants;
	[TestFixture]
	public class CreatorControllerTests
	{
		private CreatorController _controller;

		[SetUp]
		public async Task SetUp()
		{
			var creatorServiceMock = new Mock<ICreatorService>();
			_controller = new CreatorController(creatorServiceMock.Object);

			var httpContext = new DefaultHttpContext();
			var userId = Guid.NewGuid().ToString();
			var claims = new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, userId),

		};
			var identity = new ClaimsIdentity(claims, "Test");
			var principal = new ClaimsPrincipal(identity);

			httpContext.User = principal;

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = httpContext,
			};
		}

		[Test]
		public async Task Become_Get_ShouldReturnView()
		{

			var userId = Guid.NewGuid().ToString();
			var claims = new List<Claim>
			{
			  new Claim(ClaimTypes.NameIdentifier, userId)
			};

			var user = new ClaimsPrincipal(new ClaimsIdentity(claims));

			var creatorServiceMock = new Mock<ICreatorService>();
			creatorServiceMock.Setup(s => s.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(false);

			var controller = new CreatorController(creatorServiceMock.Object);
			controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = user
				}
			};

			var result = await controller.Become();

			Assert.IsInstanceOf<ViewResult>(result);
		}


		[Test]
		public async Task Become_Post_ValidModel_ShouldRedirectToHome()
		{
			var userId = Guid.NewGuid().ToString();
			var claims = new List<Claim>
	{
		new Claim(ClaimTypes.NameIdentifier, userId)
	};

			var user = new ClaimsPrincipal(new ClaimsIdentity(claims));

			var creatorServiceMock = new Mock<ICreatorService>();
			creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(false);
			creatorServiceMock.Setup(c => c.CreatorExistByPhoneNumberAsync(It.IsAny<string>())).ReturnsAsync(false);
			creatorServiceMock.Setup(c => c.Create(It.IsAny<string>(), It.IsAny<BecomeCreatorFormModel>())).Returns(Task.CompletedTask);

			var controller = new CreatorController(creatorServiceMock.Object);
			controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = user
				}
			};

			// Set up TempData
			var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
			controller.TempData = tempData;

			var model = new BecomeCreatorFormModel { PhoneNumber = "1234567890" };

			var result = await controller.Become(model);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectResult = result as RedirectToActionResult;
			Assert.AreEqual("Home", redirectResult.ControllerName);
			Assert.AreEqual("Index", redirectResult.ActionName);

			// Check TempData value
			Assert.AreEqual("You are now a creator", tempData[SuccessMessage]);
		}


		[Test]
		public async Task Become_Post_AlreadyCreator_ShouldAddErrorMessageAndRedirectToHome()
		{
			var userId = Guid.NewGuid().ToString();
			var claims = new List<Claim>
	{
		new Claim(ClaimTypes.NameIdentifier, userId)
	};

			var creatorServiceMock = new Mock<ICreatorService>();
			creatorServiceMock.Setup(c => c.CreatorExistByUserIdAsync(It.IsAny<string>())).ReturnsAsync(true);

			var controller = new CreatorController(creatorServiceMock.Object);
			controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(claims))
				}
			};
			controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());

			var model = new BecomeCreatorFormModel { PhoneNumber = "1234567890" };

			var result = await controller.Become(model);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
			var redirectResult = result as RedirectToActionResult;
			Assert.AreEqual("Home", redirectResult.ControllerName);
			Assert.AreEqual("Index", redirectResult.ActionName);
			Assert.AreEqual("You are already a creator", controller.TempData["ErrorMessage"]);
		}


	}
}
