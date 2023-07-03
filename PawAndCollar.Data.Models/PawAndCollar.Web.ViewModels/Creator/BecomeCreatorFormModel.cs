using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PawAndCollar.Web.ViewModels.Creator
{
	using static PawAndCollar.Common.EntittyValidationConstants.Creator;
	public class BecomeCreatorFormModel
	{
		[Required]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
		[Phone]
		[Display(Name = "Phone")]
		public string PhoneNumber { get; set; } = null!;
	}
}
