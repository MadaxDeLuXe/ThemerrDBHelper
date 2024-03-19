using Newtonsoft.Json;
using System.Text;
using ThemerrDBHelper.Classes;

namespace ThemerrDBHelper.Helpers
{
    public abstract class IO
    {
        public static T? LoadFromDisk<T>(string path)
        {
            JsonSerializerSettings settings = new()
            {
                Formatting = Formatting.Indented
            };

            if (!File.Exists(path)) { return default; }

            try
            {
                return JsonDeSerialize<T>(File.ReadAllText(path), settings);
            }
            catch (Exception ex)
            {
                // TODO: Exception handling
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static bool WriteToDisk<T>(T obj, string path)
        {
            JsonSerializerSettings settings = new()
            {
                Formatting = Formatting.Indented
            };

            try
            {
                if (!Directory.Exists(path.Substring(0, path.LastIndexOf('\\')))) { Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\'))); }

                File.WriteAllText(path, JsonSerialize<T>(obj, settings));
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Exception handling
                throw new Exception(ex.Message, ex.InnerException);
            }
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

        internal static List<string> ReadLog(FileInfo FileInfo)
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

        public static string JsonSerialize<T>(T obj, JsonSerializerSettings? settings = null)
        {
            return settings is not null ? JsonConvert.SerializeObject(obj, settings) : JsonConvert.SerializeObject(obj);
        }

        public static string JsonSerialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T? JsonDeSerialize<T>(string json, JsonSerializerSettings? settings = null)
        {
            return settings is not null ? JsonConvert.DeserializeObject<T>(json, settings) : JsonConvert.DeserializeObject<T>(json);
        }

        public static T? JsonDeSerialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}