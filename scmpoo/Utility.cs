using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace scmpoo
{
    class Utility
    {

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd); 

        public static Rectangle GetRectangleAtPoint(int x, int y)
        {
            var hwnd = WindowFromPoint(x, y);
            if (hwnd == null || hwnd == IntPtr.Zero || !IsWindowVisible(hwnd) || GetWindowTextLength(hwnd) <= 0)
                return Rectangle.Empty;

            RECT rect;
            var result = GetWindowRect(hwnd, out rect);
            if (!result)
                return Rectangle.Empty;

            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left + 1, rect.Bottom - rect.Top + 1);
        }

        public static Rectangle GetScreenRect()
        {
            Rectangle r = new Rectangle();
            foreach (var scr in Screen.AllScreens)
                r = Rectangle.Union(r, scr.Bounds);
            return r;
        }

    }
}
