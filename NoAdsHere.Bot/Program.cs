using System;
using System.Dynamic;
using System.Threading.Tasks;
using Discord;
using Discord.Addons.MicrosoftLogging;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NoAdsHere.Configuration;
using NoAdsHere.Database;

namespace NoAdsHere.Bot
{
    internal class Program
    {
        private static void Main(string[] args)
            => new Program().MainAsync(args).GetAwaiter().GetResult();

        private IServiceProvider _provider;

        private ILogger _logger;
        private DiscordShardedClient _client;

        // ReSharper disable once UnusedParameter.Local
        private async Task MainAsync(string[] args)
        {
            _provider = BuildServiceProvider();

            _logger = _provider.GetRequiredService<ILogger<Program>>();
            _logger.LogInformation("Hello World!");

            // Force load the config to crete it if its not existing
            var cm = _provider.GetRequiredService<ConfigManager>().Load();

            _client = _provider.GetRequiredService<DiscordShardedClient>();
            _client.UseMicrosoftLogging(_provider.GetRequiredService<ILogger<DiscordShardedClient>>());

            // Test inset
            var unit = _provider.GetService<DatabaseUnit>();
            
            // Ensure that the Database is always up-todate
            await unit.MigrateAsync();

            await _client.LoginAsync(TokenType.Bot, cm.GlobalConfig.Bot.Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        /// <summary>
        /// Create a new ServiceProvider / Dependency Injection service
        /// </summary>
        /// <returns>A Service Provider with logging already Setup</returns>
        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace));
            services.AddDbContext<DatabaseContext>();
            services.AddSingleton<DatabaseUnit>();
            services.AddSingleton<ConfigManager>();
            services.AddSingleton(new DiscordShardedClient(
                new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Debug,
                    TotalShards = GetRecommndedShardCount()
                }));
            services.AddSingleton(new CommandService(
                new CommandServiceConfig
                {
                    LogLevel = LogSeverity.Debug,
                    IgnoreExtraArgs = true
                }));

            var serviceProvider = services.BuildServiceProvider();

            // Set up Logging
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            // Set up Logger Targets
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            return serviceProvider;
        }

        private static int GetRecommndedShardCount()
        {
            var client = new DiscordSocketClient();
            var cm = new ConfigManager().Load();

            client.LoginAsync(TokenType.Bot, cm.GlobalConfig.Bot.Token).GetAwaiter().GetResult();
            
            return client.GetRecommendedShardCountAsync().GetAwaiter().GetResult();
        }
    }
}