using PawAndCollar.Web.ViewModels.Comment;

namespace PawAndCollarServices.Interfaces
{
	public interface ICommentService
	{
		Task CreateCommentAync(CommentCreateViewModel comment, string userId);
		Task<CommentViewModel> GetCommentByIdAsync(int id);
		Task<bool> IsCommentBelongToUser(string userId, int commentId);

		Task<bool> IsCommentExistByIdAsync(int commentId);

		Task EditCommentAsync(CommentViewModel comment);
	}
}
