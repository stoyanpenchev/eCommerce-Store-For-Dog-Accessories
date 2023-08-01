using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Comment;
using PawAndCollar.Web.ViewModels.Review;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
	using static PawAndCollar.Common.NotificationMessagesConstants;

	[Authorize]
    public class CommentController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IEnumService enumService;
		private readonly ICommentService commentService;

        public CommentController(IReviewService reviewService, IEnumService enumService, ICommentService commentService)
        {
            this.reviewService = reviewService;
            this.enumService = enumService;
			this.commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int reviewId)
        {
            string? userId = this.User.GetId();

            if(userId == null)
            {
                this.TempData[ErrorMessage] = "You must be logged in to comment";
				return this.RedirectToAction("Login", "Account");
			}
			ReviewViewModel review = await this.reviewService.GetReviewByIdAsync(userId, reviewId); 


            if (review == null)
            {
                this.TempData[ErrorMessage] = "Review does not exist";
				return this.RedirectToAction("Index", "Home");
			}

            if(review.IsCustomerPurchasedProduct == false && !this.User.IsAdministrator())
            {
                this.TempData[ErrorMessage] = "You must purchase the product to comment";
				return this.RedirectToAction("Index", "Home");
			}
            try
            {
				CommentCreateViewModel comment = new CommentCreateViewModel
				{
					ReviewId = reviewId
				};
                comment.RatingTypes = this.enumService.GetEnumSelectList<RatingTypes>();
				comment.DatePosted = DateTime.UtcNow.ToString();
				comment.AuthorName = this.User.Identity.Name;
				return View(comment);
			}
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateViewModel comment)
        {
			string? userId = this.User.GetId();

			if (userId == null)
			{
				this.TempData[ErrorMessage] = "You must be logged in to comment";
				return this.RedirectToAction("Login", "Account");
			}

			ReviewViewModel review = await this.reviewService.GetReviewByIdAsync(userId, comment.ReviewId);

			if (review == null)
			{
				this.TempData[ErrorMessage] = "Review does not exist";
				return this.RedirectToAction("Index", "Home");
			}

			if (review.IsCustomerPurchasedProduct == false)
			{
				this.TempData[ErrorMessage] = "You must purchase the product to comment";
				return this.RedirectToAction("Index", "Home");
			}

			if (!ModelState.IsValid)
			{
				comment.RatingTypes = this.enumService.GetEnumSelectList<RatingTypes>();
				return View(comment);
			}

			try
			{
				await this.commentService.CreateCommentAync(comment, userId);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to create your new Comment! Please try again later or contact administrator!");
				comment.RatingTypes = this.enumService.GetEnumSelectList<RatingTypes>();
				return View(comment);
			}
			this.TempData[SuccessMessage] = "Comment was created successfully!";
			return RedirectToAction("ReviewIndex", "Review", new { id = review.Product.Id });
		}

		private IActionResult GeneralError()
		{
			this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
			return this.RedirectToAction("Index", "Home");
		}

	}
}
