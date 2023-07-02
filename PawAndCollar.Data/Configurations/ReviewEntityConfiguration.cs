using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawAndCollar.Data.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                 .HasOne(r => r.Product)
                 .WithMany(p => p.Reviews)
                 .HasForeignKey(r => r.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
