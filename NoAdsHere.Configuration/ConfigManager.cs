using System.IO;
using Newtonsoft.Json;
using NoAdsHere.Configuration.Entities;

namespace NoAdsHere.Configuration
{
    public class ConfigManager
    {
        private const string FilePath = "configuration.json";

        public GlobalConfig GlobalConfig { get; set; } = new GlobalConfig();

        /// <summary>
        /// Load The Configuration from File and update the current instance with it
        /// </summary>
        /// <returns>Also returns the current instance to use it fluently</returns>
        public ConfigManager Load()
        {
            if (!File.Exists(FilePath))
                Save();

            var cm = JsonConvert.DeserializeObject<ConfigManager>(File.ReadAllText(FilePath));
            GlobalConfig = cm.GlobalConfig;

            return this;
        }

        /// <summary>
        /// Save the current configuration to File
        /// </summary>
        public void Save() => File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
    }
}