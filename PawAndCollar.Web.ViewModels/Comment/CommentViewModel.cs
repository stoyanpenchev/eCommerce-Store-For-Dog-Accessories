using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Comment
{
    using static Common.EntittyValidationConstants.Comment;
    public class CommentViewModel
    {
        public CommentViewModel()
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
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;

		[Required(ErrorMessage = "Please select a Rating Type.")]
		public int RatingType { get; set; }

        [Required]
        public string DatePosted { get; set; } = null!;

        [Required]
        public string AuthorName { get; set; } = null!;

        public IEnumerable<SelectListItem> RatingTypes { get; set; }

    }
}
