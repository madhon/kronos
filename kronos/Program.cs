namespace Kronos
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Runtime;
    using System.Threading;
    using System.Windows.Forms;
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;

    public static class Program
    {
        internal static Mutex Mtx = new Mutex(true, "EBB8D9AE-EB98-48D3-861E-F47609501EC6");

        [STAThread]
        public static void Main()
        {
            if (Mtx.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
                    Application.ThreadException += OnThreadException;
                    PerformProfileOptimisation();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);


                    var countryCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
                    AppCenter.SetCountryCode(countryCode);

                    AppCenter.Start("6fc88650-0a91-4112-aa32-fa32e250db61",
                        typeof(Analytics), typeof(Crashes));

                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {

                    ExceptionManager.HandleException(ex);
                }
            }
            else
            {
                NativeMethods.PostMessage((IntPtr) NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero,
                    IntPtr.Zero);
            }
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionManager.HandleException(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionManager.HandleException(e.ExceptionObject as Exception);
        }

        private static void PerformProfileOptimisation()
        {
            var p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Madhon\\Kronos");
            Directory.CreateDirectory(p);
            ProfileOptimization.SetProfileRoot(p);
            ProfileOptimization.StartProfile("Kronos_Profile");
        }
    }
}
