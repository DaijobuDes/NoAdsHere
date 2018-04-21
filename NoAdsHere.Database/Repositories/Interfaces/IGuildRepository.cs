using System.Threading.Tasks;
using NoAdsHere.Database.Entities;

namespace NoAdsHere.Database.Repositories.Interfaces
{
    public interface IGuildRepository : IRepository<Guild>
    {
        void Add(int guildId);

        Task AddAsync(int guildId);
    }
}