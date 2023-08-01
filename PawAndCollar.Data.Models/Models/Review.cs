using PawAndCollar.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawAndCollar.Data.Models.Models
{
    using static Common.EntittyValidationConstants.Review;
    public class Review
    {
        public Review()
        {
            this.Comments = new List<Comment>();
        }
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; } = null!;

        [Range(typeof(double) ,MinAverageScore, MaxAverageScore)]
        public double AverageScore { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
