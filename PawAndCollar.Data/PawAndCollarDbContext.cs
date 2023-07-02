using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Models;
using System.Reflection;
using System.Reflection.Emit;

namespace PawAndCollar.Data
{
    public class PawAndCollarDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PawAndCollarDbContext(DbContextOptions<PawAndCollarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Creator> Creators { get; set; } = null!;
        public DbSet<OrderItem> OrderedItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PawAndCollarDbContext)) ?? Assembly.GetExecutingAssembly());
            builder.Entity<Product>()
             .Property(p => p.Price)
             .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
        }

    }
}