using Newtonsoft.Json;

namespace NoAdsHere.Configuration.Entities
{
    public class GlobalConfig
    {
        /// <summary>
        /// Bot specific configuration
        /// </summary>
        public BotConfig Bot { get; set; } = new BotConfig();

        /// <summary>
        /// Database specific configuration
        /// </summary>
        public DatabaseConfig Database { get; set; } = new DatabaseConfig();

        public class BotConfig
        {
            /// <summary>
            /// Discord Login Token
            /// </summary>
            [JsonProperty("token")]
            public string Token { get; set; } = "Place your Token Here";
        
            /// <summary>
            /// Global Prefix of the Bot
            /// </summary>
            [JsonProperty("prefix")]
            public string Prefix { get; set; } = "!";   
        }
        
        public class DatabaseConfig
        {
            /// <summary>
            /// The ProstgreSQL connection string
            /// </summary>
            public string ConnectionString { get; set; } = "Prostgres connection string";
        }

        
    }
}