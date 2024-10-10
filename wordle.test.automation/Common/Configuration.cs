using Newtonsoft.Json;
using System.ComponentModel;

namespace wordle.test.automation.Common
{
    public class Configuration
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("chrome")]
        public string Browser { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("http://localhost:3000")]
        public string Url { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Wordle { get; set; }
    }
}
