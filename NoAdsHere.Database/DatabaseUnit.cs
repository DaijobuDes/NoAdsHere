using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoAdsHere.Database.Repositories;
using NoAdsHere.Database.Repositories.Interfaces;

namespace NoAdsHere.Database
{
    public class DatabaseUnit
    {
        private readonly DatabaseContext _context;
        public IGuildRepository Guilds { get; }

        public DatabaseUnit(DatabaseContext context)
        {
            _context = context;
            
            Guilds = new GuildRepository(context);
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync().ConfigureAwait(false);

        public async Task MigrateAsync()
            => await _context.Database.MigrateAsync();
    }
}