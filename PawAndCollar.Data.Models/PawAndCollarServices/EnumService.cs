using Microsoft.AspNetCore.Mvc.Rendering;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
    public class EnumService : IEnumService
    {
        public IEnumerable<SelectListItem> GetEnumSelectList<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = Convert.ToInt32(e).ToString(),
                           Text = e.ToString()
                       })
                       .ToList();
        }
    }
}
