namespace Kronos
{
    using System;
    using System.IO;
    using System.Reflection;

    internal class KronosConfigurationInstance
    {
        private static readonly Lazy<KronosConfiguration> lazy = new Lazy<KronosConfiguration>(() => new KronosConfiguration());

        public KronosConfiguration Config { get; set; }

        public static KronosConfiguration Instance => lazy.Value;

        private KronosConfigurationInstance()
        {
            Config = SimpleJson.DeserializeObject<KronosConfiguration>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.json")));
        }
    }
}
