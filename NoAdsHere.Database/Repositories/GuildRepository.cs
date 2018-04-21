using System.Threading.Tasks;
using NoAdsHere.Database.Entities;
using NoAdsHere.Database.Repositories.Interfaces;

namespace NoAdsHere.Database.Repositories
{
    public class GuildRepository : Repository<Guild>, IGuildRepository
    {
        public GuildRepository(DatabaseContext context) : base(context)
        {
        }

        public void Add(int guildId)
            => Add(new Guild(guildId));

        public async Task AddAsync(int guildId)
            => await AddAsync(new Guild(guildId)).ConfigureAwait(false);
    }
}