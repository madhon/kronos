namespace Kronos
{
    using System;
    using System.IO;

    internal class KronosConfiguration
    {
        public string DataFile
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kronos",
                    "Kronos.db");
            }
        }
    }
}
