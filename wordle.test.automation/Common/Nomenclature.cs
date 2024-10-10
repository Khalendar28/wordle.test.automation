using Newtonsoft.Json;

namespace wordle.test.automation.Common
{
    public static class Nomenclature
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(type: System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static Configuration config = null;

        public static Configuration Config
        {
            get
            {
                LoadConfig();
                return config;
            }
        }

        public static string BaseUrl    = Config.Url,
                             Wordle     = Config.Wordle,
                             Browser    = Config.Browser,
                             TestUrl    = BaseUrl + $"/?test={Wordle}";



        public static void LoadConfig()
        {
            // load config from json file

            if (config == null)
            {
                string configFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"Settings\\config.json");

                log.Debug($"Loading config file: {configFilePath}");

                try
                {
                    string jsonString = File.ReadAllText(configFilePath);
                    config = JsonConvert.DeserializeObject<Configuration>(jsonString);
                    log.Debug("Config file loaded");
                }
                catch (Exception e)
                {                     
                    log.Error($"Failed to load config file, Exception = {e}");
                    throw;
                }
            }
        }
    }
}
