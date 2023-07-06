namespace PawAndCollarServices.Interfaces
{
    public interface ISizeService
    {
        Task<IEnumerable<string>> GetAllSizesAsync();
    }
}
