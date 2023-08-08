using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawAndCollar.Data.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.Product)
                .WithOne(p => p.Review)
                .HasForeignKey<Review>(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

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
