using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.Product)
                .WithOne(p => p.Review)
                .HasForeignKey<Review>(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
