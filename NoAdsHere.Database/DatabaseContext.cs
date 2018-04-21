using Microsoft.EntityFrameworkCore;
using NoAdsHere.Configuration;
using NoAdsHere.Database.Entities;

namespace NoAdsHere.Database
{
    public class DatabaseContext : DbContext
    {
        private ConfigManager _config;

        public DbSet<Guild> Guilds { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _config = new ConfigManager().Load();

            optionsBuilder.UseNpgsql(_config.GlobalConfig.Database.ConnectionString).UseMemoryCache(null);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guild>().HasKey(g => g.Id);
            modelBuilder.Entity<Guild>().Property(g => g.Id).ValueGeneratedNever();
            modelBuilder.Entity<User>().HasKey(u => new {u.GuildId, u.Id});

            base.OnModelCreating(modelBuilder);
        }
    }
}