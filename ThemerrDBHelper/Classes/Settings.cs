using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemerrDBHelper.Classes
{
    public static class Settings
    {
        public static string AppName = "ThemerrDBHelper";

        public static string DataFolder = Directory.GetCurrentDirectory() + "\\ThemerrObjects\\";
        public static string Filename = "data.thd";

        public const int MaxVideoQueue_YT = 5;
        public const int BufferSize = 128;

        public static char[] Trimchars = ['\\', '"', '/', ' ', ','];

        public static string LogFilter = "Log files (*.log)|*.log|All files (*.*)|*.*";
        public static string MissingString = "Missing from ThemerrDB: ";
        public static string ContriString = "contribute: ";

        public static string ReadLog = "Analyzing Log...";
        public static string CreateObjects = "Creating Objects...";

        public static string SearchTMDBPosters = "Searching for Posters...";
        public static string SearchYT = "Searching YouTube...";

        public static Color OKColor_BG = Color.LightGreen;
        public static Color OKColor_Sel = Color.Green;

        public static Color HMColor_BG = Color.Orange;
        public static Color HMColor_Sel = Color.Orange;

        public static Color Default_BG = SystemColors.Window;
        public static Color Default_Sel = SystemColors.Highlight;
    }
}
