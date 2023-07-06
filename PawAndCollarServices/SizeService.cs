using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models.Enums;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
    public class SizeService : ISizeService
    {
        private readonly PawAndCollarDbContext dbContext;
        public SizeService(PawAndCollarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<string>> GetAllSizesAsync()
        {
            IEnumerable<string> sizes = await this.dbContext.Products
                .Select(p => p.Size.ToString())
                .Distinct()
                .ToListAsync();
            return sizes;
        }
    }
}
