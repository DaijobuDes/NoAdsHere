using Newtonsoft.Json;

namespace NoAdsHere.Bot.Config
{
    public class GlobalConfig
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
}