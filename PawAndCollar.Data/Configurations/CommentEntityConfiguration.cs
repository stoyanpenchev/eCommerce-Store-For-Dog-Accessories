using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.Review)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateComments());
        }

        private Comment[] GenerateComments()
        {
            ICollection<Comment> comments = new List<Comment>();

            Comment comment = new Comment()
            {
                Id = 1,
                DatePosted = DateTime.UtcNow,
                Content = "Very Nice Product! I am pleased with it:)",
                ReviewId = 1,
                CustomerId = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
                RatingType = (RatingTypes)5
			};
            comments.Add(comment);

            comment = new Comment()
            {
                Id = 2,
                DatePosted = DateTime.UtcNow,
                Content = "Test from Admin. The test is looking goood!",
                ReviewId = 1,
                CustomerId = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
                RatingType = (RatingTypes)5
            };
            comments.Add(comment);

            comment = new Comment()
            {
				Id = 3,
				DatePosted = DateTime.UtcNow,
				Content = "Test with one star! It seems okay!",
				ReviewId = 1,
				CustomerId = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
				RatingType = (RatingTypes)1
			};
            comments.Add(comment);

			return comments.ToArray();
        }
    }
}
