using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Web.ViewModels.Comment;
using PawAndCollarServices.Interfaces;
using System.Net;

namespace PawAndCollarServices
{
    public class CommentService : ICommentService
    {
        private readonly PawAndCollarDbContext dbContext;
        public CommentService(PawAndCollarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task CreateCommentAync(CommentCreateViewModel comment, string userId)
		{
			string senitizedContent = WebUtility.HtmlEncode(comment.Content);
			Comment newComment = new Comment()
            {
				Id = comment.Id,
				Content = senitizedContent,
				DatePosted = DateTime.UtcNow,
				ReviewId = comment.ReviewId,
				RatingType = (RatingTypes)comment.RatingType,
				CustomerId = Guid.Parse(userId)
			};

			await this.dbContext.Comments.AddAsync(newComment);
			await dbContext.SaveChangesAsync();

			Review? review = await this.dbContext.Reviews.Where(x => x.Id == newComment.ReviewId).FirstOrDefaultAsync();
			if(review != null && review.Comments != null && review.Comments.Any())
			{
				review.AverageScore = review.Comments.Average(x => (int)x.RatingType);
				await dbContext.SaveChangesAsync();
			}
		}
	}
}
