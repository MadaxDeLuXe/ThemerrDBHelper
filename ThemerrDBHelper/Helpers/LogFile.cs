using System.Text;
using ThemerrDBHelper.Classes;

namespace ThemerrDBHelper.Helpers
{
    internal abstract class LogFile
    {
        /// <summary>
        /// Returns a List with cleaned ThemerrLogData of missing data
        /// </summary>
        /// <param name="FileInfo"></param>
        /// <returns>List<string></returns>
        internal static List<string> Read(FileInfo FileInfo)
        {
            List<string> ThemerrLogData = new();
            List<string> LogLines = new();

            using (var fs = File.OpenRead(FileInfo.FullName))
            using (var sR = new StreamReader(fs, Encoding.UTF8, true, Settings.BufferSize))
            {
                string line;
                while ((line = sR.ReadLine()) != null)
                {
                    LogLines.Add(line);
                }
            }

            if (LogLines.Any(x => x.Contains(Settings.MissingString)))
            {
                for (int i = 0; i < LogLines.Count; i++)
                {
                    if (LogLines[i].Contains(Settings.MissingString))
                    {
                        string line = $"{LogLines[i]} {LogLines[i + 1]}";
                        if (!ThemerrLogData.Contains(line))
                        {
                            ThemerrLogData.Add(line);
                            if (i <= LogLines.Count - 1) { i++; }
                        }
                    }
                }
            }
            return ThemerrLogData;
        }

        internal static FileInfo? GetLogFilePath()
        {
            FileDialog FiDi = new OpenFileDialog();
            FiDi.Filter = Settings.LogFilter;
            FiDi.FilterIndex = 1;

            if (FiDi.ShowDialog() == DialogResult.OK)
            {
                return new FileInfo(FiDi.FileName);
            }
            return default;
        }
    }
}