using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ThemerrDBHelper.Helpers
{
    public abstract class MouseOp
    {
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int x, int y);        

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static MousePoint GetCurrentLocation()
        {
            return new MousePoint(Cursor.Position.X, Cursor.Position.Y);
        }

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void LeftClick(MousePoint mLoc)
        {
            MousePoint oldPos = GetCurrentLocation();
            SetCursorPos(mLoc.X, mLoc.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            SetCursorPos(oldPos.X, oldPos.Y);
        }

        public static void RightClick(MousePoint mLoc)
        {
            MousePoint oldPos = GetCurrentLocation();
            SetCursorPos(mLoc.X, mLoc.Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
            SetCursorPos(oldPos.X, oldPos.Y);
        }
    }
}
