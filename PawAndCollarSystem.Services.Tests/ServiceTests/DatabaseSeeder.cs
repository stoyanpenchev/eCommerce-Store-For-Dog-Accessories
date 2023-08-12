using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using System;
using System.Collections;

namespace PawAndCollarSystem.Services.Tests.CreatorTests
{
	public static class DatabaseSeeder
	{
		public static ApplicationUser CreatorUser;
		public static ApplicationUser User;
		public static Creator Creator;
		public static Order OrderCreator;
		public static Order OrderUser;
		public static Product ProductCollar;
		public static Product ProductHarness;
		public static Category Collar;
		public static Category Harness;
		public static Review ReviewCollar;
		public static Comment CommentCollar;

		public static void SeedDatabase(PawAndCollarDbContext dbContext)
		{
			
			CreatorUser = new ApplicationUser()
			{
				UserName = "creator@abv.bg",
				NormalizedUserName = "CREATOR@ABV.BG",
				Email = "creator@abv.bg",
				NormalizedEmail = "CREATOR@ABV.BG",
				SecurityStamp = Guid.NewGuid().ToString(),
				IsActive = true
			};

			User = new ApplicationUser()
			{
				UserName = "doglover@abv.bg",
				NormalizedUserName = "DOGLOVER@ABV.BG",
				Email = "doglover@abv.bg",
				NormalizedEmail = "DOGLOVER@ABV.BG",
				SecurityStamp = Guid.NewGuid().ToString(),
				IsActive = true
			};

			Creator = new Creator()
			{
				PhoneNumber = "+359884156182",
				User = CreatorUser,
			};


			OrderCreator = new Order()
			{
				Status = OrderStatus.Processing,
				CustomerName = CreatorUser.UserName,
				OrderDate = DateTime.UtcNow,
				OrderNumber = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				TotalAmount = 100,
				ShippingAddress = "Sofia, Bulgaria, SofiaSofia"
			};

			OrderUser = new Order()
			{
				Status = OrderStatus.Cancelled,
				CustomerName = User.UserName,
				OrderDate = DateTime.UtcNow,
				OrderNumber = Guid.Parse("1B724B4E-70EA-42BC-5982-08DB77F1F68E"),
				TotalAmount = 100,
				ShippingAddress = "Sofia, Bulgaria, SofiaSofia"
			};

			ProductCollar = new Product()
			{
				Name = "Midnight Floral Collar",
				Description = "Midnight Floral brings out a lovely serenity. Featuring an abundance of lively flowers on a bold black background, this print is sure to stand out on any color of fur. 100% cotton fabric with the perfect touch of rose gold metal hardware.",
				Price = 52.00M,
				Quantity = 3,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614",
				CategoryId = 5,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD96"),
				Size = (SizeTypes)5,
				Color = "Midnight",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};

			ProductHarness = new Product()
			{
				Name = "Morning Floral Harness",
				Description = "One of our bestselling designs of all time. Crafted with care and attention to detail, this stunning design features an abundance of lively flowers that will add a touch of  nature's beauty to your furry friend's wardrobe.",
				Price = 81.00M,
				Quantity = 6,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/Cute-dog-harness-for-large-dogs_652c3b45-bf4f-4d1f-9532-f34971c4eff9-714245_720x.jpg?v=1669533905",
				CategoryId = 3,
				CreatorId = Guid.Parse("3CB1A111-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)1,
				Color = "Pink",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};

			Harness = new Category()
			{
				Name = "Harness"
			};

			Collar = new Category()
			{
				Name = "Collar"
			};

			ReviewCollar = new Review()
			{
				ProductId = 1,
				Product = ProductCollar,
				AverageScore = 0
			};
			CommentCollar = new Comment()
			{
				DatePosted = DateTime.UtcNow,
				Content = "This is a comment This is a comment This is a comment",
				ReviewId = ReviewCollar.Id,
				RatingType = RatingTypes.FiveStars,
				CustomerId = User.Id
			};
			ReviewCollar.Comments.Add(CommentCollar);

			dbContext.Orders.Add(OrderCreator);
			dbContext.Orders.Add(OrderUser);
			dbContext.Users.Add(CreatorUser);
			dbContext.Users.Add(User);
			dbContext.Creators.Add(Creator);
			dbContext.Products.Add(ProductCollar);
			dbContext.Products.Add(ProductHarness);
			dbContext.Categories.Add(Harness);
			dbContext.Categories.Add(Collar);
			dbContext.Reviews.Add(ReviewCollar);
			dbContext.SaveChanges();
		}
	}
}
