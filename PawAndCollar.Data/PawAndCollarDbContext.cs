using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data.Configurations;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Data.Seeds;
using System.Reflection;

namespace PawAndCollar.Data
{
    public class PawAndCollarDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
		private readonly bool seedDb;
		public PawAndCollarDbContext(DbContextOptions<PawAndCollarDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Creator> Creators { get; set; } = null!;
        public DbSet<OrderItem> OrderedItems { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<UsersBuyedProducts> UsersBuyedProducts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
			//builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PawAndCollarDbContext)) ?? Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new OrderItemEntityConfiguration());
            builder.ApplyConfiguration(new CartEntityConfiguration());
            builder.ApplyConfiguration(new CommentEntityConfiguration());
            builder.ApplyConfiguration(new ReviewEntityConfiguration());

			if (this.seedDb)
			{
				builder.ApplyConfiguration(new CategoryEntityConfiguration());
				builder.ApplyConfiguration(new SeedApplicationUserEntityConfiguration());
                builder.ApplyConfiguration(new SeedProductsEntityConfiguration());
                builder.ApplyConfiguration(new SeedCartEntityConfiguration());
                builder.ApplyConfiguration(new SeedReviewEntityConfiguration());
				builder.ApplyConfiguration(new CreatorEnityConfiguration());
				builder.ApplyConfiguration(new OrderEntityConfiguration());
				builder.ApplyConfiguration(new UserBuyedProductsEntityConfiguration());
			}

			base.OnModelCreating(builder);
        }

    }
}