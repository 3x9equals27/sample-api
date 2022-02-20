using Cheezy.Database.Models;
using Cheezy.Enums;
using Microsoft.EntityFrameworkCore;

namespace Cheezy.Database
{
    public class CheezyRepo : ICheezyRepo
    {
        private readonly CheezyContext _context;
        public CheezyRepo(CheezyContext cheezyContext)
        {
            _context = cheezyContext;
        }

        public async Task<Cheese> GetRandomCheese(Taste taste)
        {
            return await _context.Cheese
                .Where(x => x.Taste == taste)
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefaultAsync();
        }

        public async Task<Cheese> GetRandomCheese()
        {
            return await _context.Cheese
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefaultAsync();
        }
    }
}
