﻿namespace Kronos
{
    using System;
    using System.IO;
    using System.Runtime;
    using System.Threading;
    using System.Windows.Forms;

    public static class Program
    {
        private static readonly Mutex Mtx = new Mutex(true, "EBB8D9AE-EB98-48D3-861E-F47609501EC6");

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
            var ex = e.ExceptionObject as Exception;

            ExceptionManager.HandleException(ex);
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
