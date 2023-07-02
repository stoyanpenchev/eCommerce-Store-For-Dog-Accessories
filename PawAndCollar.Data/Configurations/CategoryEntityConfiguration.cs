
namespace PawAndCollar.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PawAndCollar.Data.Models;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new List<Category>();
            Category category = new Category()
            {
                Id = 1,
                Name = "Collars"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 2,
                Name = "Leash"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 3,
                Name = "Harness"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 4,
                Name = "Bow Tie Collars"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 5,
                Name = "Flower Collars"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 6,
                Name = "Bow Ties / Flowers"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 7,
                Name = "Bandanas"
            };
            categories.Add(category);
            category = new Category()
            {
                Id = 8,
                Name = "Reversible Vests"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
