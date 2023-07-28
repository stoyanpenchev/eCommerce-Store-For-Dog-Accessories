using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	using static Common.GeneralApplicationConstants;
	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		public ApplicationUserEntityConfiguration(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
		}
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder
			.HasOne(u => u.ActiveCart)
			.WithOne()
			.HasForeignKey<ApplicationUser>(u => u.CartId)
			.OnDelete(DeleteBehavior.Restrict);

			//builder.HasData(this.GenerateUsers());
		}

		//private async Task<ApplicationUser[]> GenerateUsers()
		//{
		//	var hasher = new PasswordHasher<ApplicationUser>();

		//	ICollection<ApplicationUser> users = new List<ApplicationUser>();
		//	ApplicationUser user = new ApplicationUser()
		//	{
		//		Id = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
		//		UserName = "Admin@abv.bg",
		//		NormalizedUserName = "ADMIN@ABV.BG",
		//		Email = "Admin@abv.bg",
		//		NormalizedEmail = "ADMIN@ABV.BG"
		//	};
		//	user.PasswordHash =
		//	hasher.HashPassword(user, "admin123");

		//	if (!await this.roleManager.RoleExistsAsync(AdminRoleName))
		//	{
		//		var role = new IdentityRole<Guid>(AdminRoleName);
		//		await this.roleManager.CreateAsync(role);
		//	}

		//	await userManager.AddToRoleAsync(user, AdminRoleName);

		//	users.Add(user);
		//	user = new ApplicationUser()
		//	{
		//		Id = Guid.Parse("7F8A1988-0D6F-48CF-5993-08DB77F1F68E"),
		//		UserName = "creator@abv.bg",
		//		NormalizedUserName = "CREATOR@ABV.BG",
		//		Email = "creator@abv.bg",
		//		NormalizedEmail = "CREATOR@ABV.BG",
		//		PhoneNumber = "+359884156182"
		//	};
		//	user.PasswordHash =
		//	hasher.HashPassword(user, "creator123");

		//	if (!await this.roleManager.RoleExistsAsync(UserRoleName))
		//	{
		//		var role = new IdentityRole<Guid>(UserRoleName);
		//		await this.roleManager.CreateAsync(role);
		//	}

		//	await userManager.AddToRoleAsync(user, UserRoleName);

		//	users.Add(user);

		//	user = new ApplicationUser()
		//	{
		//		Id = Guid.Parse("7B724B4E-70EA-42BC-5992-08DB77F1F68E"),
		//		UserName = "doglover@abv.bg",
		//		NormalizedUserName = "DOGLOVER@ABV.BG",
		//		Email = "doglover@abv.bg",
		//		NormalizedEmail = "DOGLOVER@ABV.BG"
		//	};
		//	user.PasswordHash =
		//	hasher.HashPassword(user, "doglover123");

		//	if (!await this.roleManager.RoleExistsAsync(UserRoleName))
		//	{
		//		var role = new IdentityRole<Guid>(UserRoleName);
		//		await this.roleManager.CreateAsync(role);
		//	}

		//	await userManager.AddToRoleAsync(user, UserRoleName);

		//	users.Add(user);

		//	user = new ApplicationUser()
		//	{
		//		Id = Guid.Parse("72614ADA-8036-426A-8335-6F286043DF35"),
		//		UserName = "creator2@abv.bg",
		//		NormalizedUserName = "CREATOR2@ABV.BG",
		//		Email = "creator2@abv.bg",
		//		NormalizedEmail = "CREATOR2@ABV.BG",
		//		PhoneNumber = "+359884532194"
		//	};

		//	user.PasswordHash =
		//	hasher.HashPassword(user, "creator2333");

		//	if (!await this.roleManager.RoleExistsAsync(UserRoleName))
		//	{
		//		var role = new IdentityRole<Guid>(UserRoleName);
		//		await this.roleManager.CreateAsync(role);
		//	}

		//	await userManager.AddToRoleAsync(user, UserRoleName);

		//	return users.ToArray();
		//}
	}
}
