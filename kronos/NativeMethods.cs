namespace Kronos;

using System;
using System.Runtime.InteropServices;

internal static partial class NativeMethods
{
    public const int HWND_BROADCAST = 0xffff;
        
    public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");

    [LibraryImport("user32.dll",
        EntryPoint = "PostMessage",
        SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        
    [LibraryImport("user32.dll", 
        EntryPoint = "RegisterWindowMessageW",
        StringMarshalling = StringMarshalling.Utf16,
        SetLastError = true)]
    public static partial int RegisterWindowMessage(string message);
}