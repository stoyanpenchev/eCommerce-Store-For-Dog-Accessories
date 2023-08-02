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
    using System.Text.Encodings.Web;

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
            if (reviewId == null)
            {
                this.TempData[ErrorMessage] = "Review does not exist";
                return this.RedirectToAction("Index", "Home");
            }
            string? userId = this.User.GetId();

            if (userId == null)
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

            if (review.IsCustomerPurchasedProduct == false && !this.User.IsAdministrator())
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
                comment.AuthorName = this.User.Identity.Name;
                comment.DatePosted = DateTime.UtcNow.ToString();
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
                this.TempData[SuccessMessage] = "Comment created successfully!";
                return RedirectToAction("ReviewIndex", "Review", new { id = review.Product.Id });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to create your new Comment! Please try again later or contact administrator!");
                comment.RatingTypes = this.enumService.GetEnumSelectList<RatingTypes>();
                return View(comment);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //	string userId = this.User.GetId();
        //	if (userId == null)
        //	{
        //		this.TempData[ErrorMessage] = "You must be logged in to edit comment";
        //		return this.RedirectToAction("Login", "Account");
        //	}
        //	bool isCommentExist = await this.commentService.IsCommentExistByIdAsync(id);
        //	if (!isCommentExist)
        //	{
        //		this.TempData[ErrorMessage] = "Comment does not exist";
        //		return this.RedirectToAction("Index", "Home");
        //	}
        //	bool isCommentBelongToUser = await this.commentService.IsCommentBelongToUser(userId, id);
        //	if (!isCommentBelongToUser)
        //	{
        //		this.TempData[ErrorMessage] = "That Comment is not yours!";
        //		return this.RedirectToAction("Index", "Home");
        //	}
        //	try
        //	{
        //              CommentViewModel comment = await this.commentService.GetCommentByIdAsync(id);
        //		comment.RatingTypes = this.enumService.GetEnumSelectList<RatingTypes>();

        //		return View("ReviewIndex", comment);
        //	}
        //	catch (Exception)
        //	{
        //		return this.GeneralError();
        //	}
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(CommentViewModel comment)
        {
            ReviewViewModel review = await this.reviewService.GetReviewByCommentIdAsync(comment.Id);
            if (review == null)
            {
                this.TempData[ErrorMessage] = "Review does not exist";
                return this.RedirectToAction("Index", "Home");
            }
            string userId = this.User.GetId();
            if (userId == null)
            {
                this.TempData[ErrorMessage] = "You must be logged in to edit comment";
                return this.RedirectToAction("Login", "Account");
            }
            bool isCommentExist = await this.commentService.IsCommentExistByIdAsync(comment.Id);
            if (!isCommentExist)
            {
                this.TempData[ErrorMessage] = "Comment does not exist";
                return this.RedirectToAction("Index", "Home");
            }
            bool isCommentBelongToUser = await this.commentService.IsCommentBelongToUser(userId, comment.Id);
            if (!isCommentBelongToUser)
            {
                this.TempData[ErrorMessage] = "That Comment is not yours!";
                return this.RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                comment.RatingTypes = this.enumService.GetEnumSelectList<RatingTypes>();
                ViewBag.ShowEditForm = true;
                return RedirectToAction("ReviewIndex", "Review", new { id = review.Product.Id });
            }

            comment.AuthorName = this.User.Identity.Name;
            comment.DatePosted = DateTime.UtcNow.ToString();
            try
            {
                await this.commentService.EditCommentAsync(comment);
                this.TempData[SuccessMessage] = "Comment edited successfully!";
                return RedirectToAction("ReviewIndex", "Review", new { id = review.Product.Id });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
            return this.RedirectToAction("Index", "Home");
        }

    }
}
