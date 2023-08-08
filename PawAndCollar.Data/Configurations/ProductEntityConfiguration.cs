using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.IsActive)
			       .HasDefaultValue(true);

			builder.Property(p => p.Price)
			       .HasColumnType("decimal(18,2)");
			builder
				.Property(p => p.CreatedOn)
				.HasDefaultValueSql("GETDATE()");
			builder
				.HasOne(h => h.Creator)
				.WithMany(a => a.Products)
				.HasForeignKey(h => h.CreatorId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(h => h.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(h => h.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(p => p.Review)
                   .WithOne(r => r.Product)
                   .HasForeignKey<Review>(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

			builder.HasData(this.GenerateProducts());
		}

		private Product[] GenerateProducts()
		{
			ICollection<Product> products = new List<Product>();

			//------------ Product COLLAR
			Product product = new Product()
			{
				Id = 1,
				Name = "Checker Pink Collar",
				Description = "Soft and sustainable fabric on the outside & inside, so even the most sensitive pups can stay comfortable all day long.\r\nCozy Fleece Vest: Machine wash cold on delicate cycle or hand wash. Air dry.",
				Price = 52.00M,
				Quantity = 10,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC03178-1-148760_720x.jpg?v=1679180307",
				CategoryId = 1,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)5,
				Color = "Pink",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			//---------------- Product COLLAR
			product = new Product()
			{
				Id = 2,
				Name = "Anemone Collar",
				Description = "In the meadows of Europe, North America, and Japan, where secrets whisper on gentle breezes, the anemone dances, an ethereal wildflower.\r\n\r\nSymbolizing understated allure, this fragile blossom enchants hearts, its subtle loveliness imbuing floral tapestries with a touch of quiet power.",
				Price = 52.00M,
				Quantity = 2,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC06736-1_d5aa7dd9-1769-47a1-affb-98d78ba9fb86-812247_720x.jpg?v=1687945201",
				CategoryId = 1,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)1,
				Color = "Anemone",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			//---------------- Product COLLAR
			product = new Product()
			{
				Id = 3,
				Name = "Suns Collar",
				Description = "A part of our boho collection including Suns, Stars, Rainbows, and lightnings. This collection is perfect for the boho, minimalist, and chic pups. Seamless Sun on lovely shade of terracotta-orange background.",
				Price = 52.00M,
				Quantity = 15,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/cute-dog-collars-girl_c89dd21c-4f50-4bf3-9dd4-32198ee0737a-429779_720x.jpg?v=1669923706",
				CategoryId = 1,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)5,
				Color = "Brown",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			//---------------- Product COLLAR

			product = new Product()
			{
				Id = 4,
				Name = "Midnight Floral Collar",
				Description = "Midnight Floral brings out a lovely serenity. Featuring an abundance of lively flowers on a bold black background, this print is sure to stand out on any color of fur. 100% cotton fabric with the perfect touch of rose gold metal hardware.",
				Price = 52.00M,
				Quantity = 3,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614",
				CategoryId = 5,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)5,
				Color = "Midnight",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			//---------------- Product Harness

			product = new Product()
			{
				Id = 5,
				Name = "Morning Floral Harness",
				Description = "One of our bestselling designs of all time. Crafted with care and attention to detail, this stunning design features an abundance of lively flowers that will add a touch of  nature's beauty to your furry friend's wardrobe.",
				Price = 81.00M,
				Quantity = 6,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/Cute-dog-harness-for-large-dogs_652c3b45-bf4f-4d1f-9532-f34971c4eff9-714245_720x.jpg?v=1669533905",
				CategoryId = 3,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)1,
				Color = "Pink",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};

			products.Add(product);

			product = new Product()
			{
				Id = 6,
				Name = "Cozy Christmas Harness",
				Description = "Give your pup the gift of coziness with our Cozy Christmas design! This dark navy blue print is filled with adorable holiday elements that will have your furry friend feeling warm and snug, making it the perfect addition to their winter wardrobe.",
				Price = 81.00M,
				Quantity = 6,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/cutest-harness-for-puppy-418532_720x.jpg?v=1669533830",
				CategoryId = 3,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)6,
				Color = "Darky",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			product = new Product()
			{
				Id = 7,
				Name = "Peach Harness",
				Description = "One of our most loved prints of all time. This delicious peach print will make your pup's cuteness irresistible. Featuring seamless Juicy peaches on a lovely peach-pink background.",
				Price = 81.00M,
				Quantity = 8,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/Best-dog-harnesses-490084_720x.jpg?v=1669620377",
				CategoryId = 3,
				CreatorId = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				Size = (SizeTypes)7,
				Color = "Peachy Pink",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			product = new Product()
			{
				Id = 8,
				Name = "Gentleman Bow Tie Collar",
				Description = "This is a true showstopper. With its timeless tartan pattern, our Gentleman design is the epitome of sophisticated style for your pup. ",
				Price = 62.00M,
				Quantity = 5,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/Cute-dog-collars-girl-999347_720x.jpg?v=1669663616",
				CategoryId = 6,
				CreatorId = Guid.Parse("20B110EC-107C-4B88-9BD4-56F4D297B179"),
				Size = (SizeTypes)2,
				Color = "English Green",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};

			products.Add(product);

			product = new Product()
			{
				Id = 9,
				Name = "Red Polka Dot Bow Tie Collar",
				Description = "Classic polka dot with bright striking red background. The Versatility is perfect for any occasion and will always make sure your pup stands out from the crowd. One of our most loved designs of all time.",
				Price = 62.00M,
				Quantity = 5,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/bowtie-collars-for-large-dogs-509429_720x.jpg?v=1669836746",
				CategoryId = 6,
				CreatorId = Guid.Parse("20B110EC-107C-4B88-9BD4-56F4D297B179"),
				Size = (SizeTypes)2,
				Color = "English Green",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			product = new Product()
			{
				Id = 10,
				Name = "Purple Daisy Reversible Zoomies Rain Vest",
				Description = "Made with premium waterproof shell on one side, and 360° reflective material on the other. You've got functionality and adorableness - all in one.",
				Price = 91.00M,
				Quantity = 15,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/ZoomiesRainvest_1-512091_720x.jpg?v=1677154390",
				CategoryId = 8,
				CreatorId = Guid.Parse("20B110EC-107C-4B88-9BD4-56F4D297B179"),
				Size = (SizeTypes)3,
				Color = "Purple",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};
			products.Add(product);

			product = new Product()
			{
				Id = 11,
				Name = "Playground Bandana",
				Description = "Beautifully illustrated by Vancouver local artist @hye.joy. This print brings out the liveliness of a spring playground with unique line illustrations, paired with a beautiful shade of olive background.",
				Price = 44.00M,
				Quantity = 15,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/DSC00043-1-238909_720x.jpg?v=1687529058",
				CategoryId = 7,
				CreatorId = Guid.Parse("20B110EC-107C-4B88-9BD4-56F4D297B179"),
				Size = (SizeTypes)3,
				Color = "Green",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};

			products.Add(product);

			product = new Product()
			{
				Id = 12,
				Name = "Cozy Christmas Bandana",
				Description = "Give your pup the gift of coziness with our Cozy Christmas design! This dark navy blue print is filled with adorable holiday elements that will have your furry friend feeling warm and snug, making it the perfect addition to their winter wardrobe.",
				Price = 44.00M,
				Quantity = 15,
				ImageUrl = "https://sniffandbark.com.co/cdn/shop/products/Bandanas-for-dogs_7aad35d9-b940-49bd-8895-9f8bb74dc6dd-759894_720x.jpg?v=1668643303",
				CategoryId = 7,
				CreatorId = Guid.Parse("20B110EC-107C-4B88-9BD4-56F4D297B179"),
				Size = (SizeTypes)5,
				Color = "Christmas",
				Material = "Cotton",
				CreatedOn = DateTime.UtcNow,
				IsActive = true
			};

			products.Add(product);

			return products.ToArray();
		}
	}
}
