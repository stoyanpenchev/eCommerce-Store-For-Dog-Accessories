using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class CreatorEnityConfiguration : IEntityTypeConfiguration<Creator>
	{
		public void Configure(EntityTypeBuilder<Creator> builder)
		{
			builder.HasData(this.GenerateCreators());
		}

		private Creator[] GenerateCreators()
		{
			ICollection<Creator> creators = new List<Creator>();
			Creator creator = new Creator()
			{
				Id = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
				UserId = Guid.Parse("7F8A1988-0D6F-48CF-5993-08DB77F1F68E"),
				PhoneNumber = "+359884156182"
			};
			creators.Add(creator);

			creator = new Creator()
			{
				Id = Guid.Parse("20B110EC-107C-4B88-9BD4-56F4D297B179"),
				UserId = Guid.Parse("9CAF16D5-298E-406A-A3DA-69DCDA2E5E27"),
				PhoneNumber = "+359884562194"
			};
			creators.Add(creator);

			return creators.ToArray();
		}
	}
}
