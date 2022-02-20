using Cheezy.Database.Models;
using Cheezy.Enums;

namespace Cheezy.Database
{
    public interface ICheezyRepo
    {
        Task<Cheese> GetRandomCheese();
        Task<Cheese> GetRandomCheese(Taste taste);
    }
}