namespace Kronos
{
    using System;
    using System.Windows.Forms;
    using Microsoft.AppCenter.Crashes;
    using Microsoft.SqlServer.MessageBox;

    internal static class ExceptionManager
    {
        public static void HandleException(Exception ex)
        {
            HandleException(ex, "Kronos", null);
        }

        public static void HandleException(Exception ex, string caption)
        {
            HandleException(ex, caption, null);
        }

        public static void HandleException(Exception ex, string caption, IWin32Window owner)
        {
            Crashes.TrackError(ex);

            var box = new ExceptionMessageBox(ex.UnWrap()) {Caption = caption};
            box.Show(owner);
        }
    }
}
