namespace Kronos
{
    using System;
    using System.IO;

    public sealed class KronosConfiguration
    {
        public string DataFile => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kronos",
            "Kronos.db");
    }
}
