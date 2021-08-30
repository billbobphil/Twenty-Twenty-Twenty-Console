using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Twenty_Twenty_Twenty_Console
{
    public static class ConfigurationManager
    {
        public static int MinutesBetweenReminders { get; set; } = 20;
        private static readonly string ConfigFileLocation = @$"{Directory.GetCurrentDirectory()}\twentyConfig.json";
        
        public static void InitializeConfiguration()
        {
            if (!File.Exists(ConfigFileLocation)) return;
            
            string json = File.ReadAllText(ConfigFileLocation);
            Configuration config = JsonConvert.DeserializeObject<Configuration>(json);
            if (config != null)
            {
                MinutesBetweenReminders = config.MinutesToWait;   
            }
        }
    }
}
