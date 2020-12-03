namespace Kronos
{
    using System;
    using System.Runtime.InteropServices;

    internal static class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
