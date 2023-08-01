namespace PawAndCollar.Web.ViewModels.Comment
{
	using Microsoft.AspNetCore.Mvc.Rendering;
	using System.ComponentModel.DataAnnotations;
    using static Common.EntittyValidationConstants.Comment;
    public class CommentCreateViewModel
    {
        public CommentCreateViewModel()
        {
			this.RatingTypes = new List<SelectListItem>
			{
				new SelectListItem { Value = "1", Text = "1" },
				new SelectListItem { Value = "2", Text = "2" },
				new SelectListItem { Value = "3", Text = "3" },
				new SelectListItem { Value = "4", Text = "4" },
				new SelectListItem { Value = "5", Text = "5" },
			};
		}
        public int Id { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;

        public int ReviewId { get; set; }

        public int RatingType { get; set; }

        [Required]
        public string DatePosted { get; set; } = null!;

        [Required]
        public string AuthorName { get; set; } = null!;

        public IEnumerable<SelectListItem> RatingTypes { get; set; }
	}
}
