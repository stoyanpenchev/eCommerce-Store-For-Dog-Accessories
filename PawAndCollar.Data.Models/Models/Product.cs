using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Models
{
    using static Common.EntittyValidationConstants.Product;
    public class Product
    {
        public Product()
        {
            this.OrderedItems = new List<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		[Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        //[ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }
        [Required]
        public Creator Creator { get; set; } = null!;

        public bool IsActive { get; set; }
        public Guid? ApplicationUserId { get; set; }

		public virtual ApplicationUser? User { get; set; }

        [ForeignKey(nameof(Review))]
        public int? ReviewId { get; set; }
        public Review? Review { get; set; }

        [Required]
        [EnumDataType(typeof(SizeTypes))]
        public SizeTypes Size { get; set; }

        [Required]
        [StringLength(ColorMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        [StringLength(MaterialMaxLength)]
        public string Material { get; set; } = null!;


        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}
