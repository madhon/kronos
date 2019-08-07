namespace Kronos
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    internal class KronosConfigurationInstance
    {
        private static readonly Lazy<KronosConfiguration> lazy = new Lazy<KronosConfiguration>(() => new KronosConfiguration());

        public KronosConfiguration Config { get; set; }

        public static KronosConfiguration Instance => lazy.Value;

        private KronosConfigurationInstance()
        {
            var configFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Madhon", "Kronos", "appSettings.json");

            Config = JsonConvert.DeserializeObject<KronosConfiguration>(File.ReadAllText(configFile));
        }
    }
}
