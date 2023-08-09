using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Seeds
{
	public class SeedReviewEntityConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.HasData(this.GenerateReviews());
		}
		private Review[] GenerateReviews()
		{
			ICollection<Review> reviews = new List<Review>();

			Review review = new Review()
			{
				Id = 1,
				ProductId = 11,
				AverageScore = 3.66666666666667
			};

			reviews.Add(review);

			review = new Review()
			{
				Id = 2,
				ProductId = 8,
				AverageScore = 0
			};
			reviews.Add(review);
			return reviews.ToArray();
		}
	}
}
