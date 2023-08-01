using PawAndCollar.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawAndCollar.Data.Models.Models
{
    using static Common.EntittyValidationConstants.Comment;
    public class Comment
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        [StringLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Review))]
        public int ReviewId { get; set; }
        [Required]
        public Review Review { get; set; } = null!;

        [EnumDataType(typeof(RatingTypes))]
        public RatingTypes? RatingType { get; set; }

        [Required, ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        [Required]
        public ApplicationUser Customer { get; set; } = null!;

    }
}
