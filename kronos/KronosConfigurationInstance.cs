namespace Kronos
{
    using System;
    using System.IO;
    using System.Text.Json;

    public class KronosConfigurationInstance
    {
        private static readonly Lazy<KronosConfiguration> lazy = new Lazy<KronosConfiguration>(() => new KronosConfiguration());

        public KronosConfiguration Config { get; set; }

        public static KronosConfiguration Instance => lazy.Value;

        private KronosConfigurationInstance()
        {
            var configFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Madhon", "Kronos", "appSettings.json");

            Config = JsonSerializer.Deserialize<KronosConfiguration>(File.ReadAllText(configFile), KronosConfigurationSerializationContext.Default.KronosConfiguration)!;
        }
    }
}
