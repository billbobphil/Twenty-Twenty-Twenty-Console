using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Twenty_Twenty_Twenty_Console
{
    public static class PromptWindowUtilities
    {

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        private const int MaximizeCode = 3;
        private const int MinimizeCode = 2;

        public static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, MaximizeCode);
        }

        public static void Minimize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, MinimizeCode); //SW_MINIMIZE = 2
        }
    }
}
