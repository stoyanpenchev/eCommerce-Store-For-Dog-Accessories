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
			if (review != null && review.Comments != null && review.Comments.Any())
			{
				review.AverageScore = review.Comments.Average(x => (int)x.RatingType);
				await dbContext.SaveChangesAsync();
			}
		}

		public async Task DeleteCommentAsync(CommentViewModel comment)
		{
			Comment? commentToDelete = await this.dbContext.Comments.Where(x => x.Id == comment.Id).FirstOrDefaultAsync();
			if (commentToDelete != null)
			{
				Review? review = await this.dbContext.Reviews.Where(x => x.Id == commentToDelete.ReviewId).FirstOrDefaultAsync();

				this.dbContext.Comments.Remove(commentToDelete);

				if (review != null && review.Comments != null && review.Comments.Any())
				{
					review.AverageScore = review.Comments.Average(x => (int)x.RatingType);
					await dbContext.SaveChangesAsync();
				}
				if (review.Comments.Count == 0)
				{
					review.AverageScore = 0;
					await dbContext.SaveChangesAsync();
				}
				await dbContext.SaveChangesAsync();
			}
		}

		public async Task EditCommentAsync(CommentViewModel comment)
		{
			Comment? dbComment = await this.dbContext.Comments.Where(x => x.Id == comment.Id).FirstOrDefaultAsync();

			string senitizedContent = WebUtility.HtmlEncode(comment.Content);
			if (dbComment != null)
			{
				Review? review = await this.dbContext.Reviews.Where(x => x.Id == dbComment.ReviewId).FirstOrDefaultAsync();
				dbComment.Content = senitizedContent;
				dbComment.RatingType = (RatingTypes)comment.RatingType;
				dbComment.DatePosted = DateTime.UtcNow;
				review.AverageScore = review.Comments.Average(x => (int)x.RatingType);
				await dbContext.SaveChangesAsync();
			}

		}

		public async Task<CommentViewModel> GetCommentByIdAsync(int id)
		{
			CommentViewModel? comment = await this.dbContext.Comments
				.Include(x => x.Customer)
				.Where(x => x.Id == id)
				.Select(x => new CommentViewModel
				{
					Id = x.Id,
					Content = x.Content,
					RatingType = (int)x.RatingType,
					AuthorName = x.Customer.UserName,
					DatePosted = x.DatePosted.ToString()
				}).FirstOrDefaultAsync();

			return comment;
		}

		public async Task<bool> IsCommentBelongToUser(string userId, int commentId)
		{
			return await this.dbContext.Comments.AnyAsync(x => x.Id == commentId && x.CustomerId == Guid.Parse(userId));
		}

		public async Task<bool> IsCommentExistByIdAsync(int commentId)
		{
			return await this.dbContext.Comments.AnyAsync(x => x.Id == commentId);
		}
	}
}
