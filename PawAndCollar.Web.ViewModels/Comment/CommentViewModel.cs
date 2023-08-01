using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Comment
{
    using static Common.EntittyValidationConstants.Comment;
    public class CommentViewModel
    {
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

	}
}
