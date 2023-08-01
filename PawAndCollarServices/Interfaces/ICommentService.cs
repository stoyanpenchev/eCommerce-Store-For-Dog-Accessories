using PawAndCollar.Web.ViewModels.Comment;

namespace PawAndCollarServices.Interfaces
{
	public interface ICommentService
	{
		Task CreateCommentAync(CommentCreateViewModel comment, string userId);
	}
}
