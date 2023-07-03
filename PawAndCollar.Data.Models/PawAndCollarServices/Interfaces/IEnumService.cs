using Microsoft.AspNetCore.Mvc.Rendering;

namespace PawAndCollarServices.Interfaces
{
    public interface IEnumService
    {
        IEnumerable<SelectListItem> GetEnumSelectList<TEnum>();
    }
}
