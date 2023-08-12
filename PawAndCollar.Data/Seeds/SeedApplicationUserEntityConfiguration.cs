using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Seeds
{
	public class SeedApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.HasData(this.GenerateUsers());
		}
		private ApplicationUser[] GenerateUsers()
		{
			var hasher = new PasswordHasher<ApplicationUser>();

			ICollection<ApplicationUser> users = new List<ApplicationUser>();

			//------------ Admin
			ApplicationUser user = new ApplicationUser()
			{
				Id = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
				UserName = "Admin@abv.bg",
				NormalizedUserName = "ADMIN@ABV.BG",
				Email = "Admin@abv.bg",
				PhoneNumber = "+359884562194",
				IsActive = true,
				NormalizedEmail = "ADMIN@ABV.BG",
				SecurityStamp = Guid.NewGuid().ToString()
			};
			user.PasswordHash =
			hasher.HashPassword(user, "admin123");

			users.Add(user);

			//------------ Creator
			user = new ApplicationUser()
			{
				Id = Guid.Parse("7F8A1988-0D6F-48CF-5993-08DB77F1F68E"),
				UserName = "creator@abv.bg",
				NormalizedUserName = "CREATOR@ABV.BG",
				Email = "creator@abv.bg",
				PhoneNumber = "+359884156182",
				IsActive = true,
				NormalizedEmail = "CREATOR@ABV.BG",
				SecurityStamp = Guid.NewGuid().ToString()
			};
			user.PasswordHash =
			hasher.HashPassword(user, "creator123");

			users.Add(user);


			//----------------- User
			user = new ApplicationUser()
			{
				Id = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
				UserName = "doglover@abv.bg",
				NormalizedUserName = "DOGLOVER@ABV.BG",
				Email = "doglover@abv.bg",
				IsActive = true,
				NormalizedEmail = "DOGLOVER@ABV.BG",
				SecurityStamp = Guid.NewGuid().ToString()
			};
			user.PasswordHash =
			hasher.HashPassword(user, "doglover123");

			users.Add(user);

			return users.ToArray();
		}
	}
}
