using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawAndCollar.Data.Models.Models;

namespace PawAndCollar.Data.Configurations
{
	public class CreatorEnityConfiguration : IEntityTypeConfiguration<Creator>
	{
		public void Configure(EntityTypeBuilder<Creator> builder)
		{
			//builder.HasData(this.GenerateCreators());
		}

		//private Creator[] GenerateCreators()
		//{
		//	ICollection<Creator> creators = new List<Creator>();
		//	Creator creator = new Creator()
		//	{
		//		Id = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD11"),
		//		UserId = Guid.Parse("7F8A1988-0D6F-48CF-5993-08DB77F1F68E"),
		//		PhoneNumber = "+359884156182"
		//	};
		//	creators.Add(creator);

		//	creator = new Creator()
		//	{
		//		Id = Guid.Parse("41D98026-111E-4647-82B7-AB0C88195CE5"),
		//		UserId = Guid.Parse("72614ADA-8036-426A-8335-6F286043DF35"),
		//		PhoneNumber = "+359884532194"
		//	};
		//	creators.Add(creator);

		//	return creators.ToArray();
		//}
	}
}
