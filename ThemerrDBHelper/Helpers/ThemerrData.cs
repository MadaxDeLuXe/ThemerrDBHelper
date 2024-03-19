using ThemerrDBHelper.Classes;

namespace ThemerrDBHelper.Helpers
{
    public abstract class ThemerrData
    {
        public static string Clean(string s)
        {
            return s.Split(new string[] { Settings.MissingString }, StringSplitOptions.None)[1].TrimStart(Settings.Trimchars).TrimEnd(Settings.Trimchars);
        }

        public static string GetName(string s)
        {
            return s.Substring(0, s.IndexOf('"')).Trim();
        }

        public static string GetContriURL(string s)
        {
            return s.Split(new string[] { Settings.ContriString }, StringSplitOptions.None)[1].TrimStart(Settings.Trimchars);
        }

        public static string GetTmdbURL(string s)
        {
            return s.Substring(s.LastIndexOf('=') + 1, s.Length - s.LastIndexOf('=') - 1);
        }

        public static string GetTmdbID(string s)
        {
            return s.Substring(s.LastIndexOf('/') + 1, s.Length - s.LastIndexOf('/') - 1);
        }

        public static ThemerrDbObject.MediaType GetMediaType(string s)
        {
            return s.Substring(s.IndexOf('[') + 1, s.IndexOf(']') - s.IndexOf('[') - 1) switch
            {
                "MOVIE" => ThemerrDbObject.MediaType.Movie,
                "TV SHOW" => ThemerrDbObject.MediaType.TVShow,
                "GAME" => ThemerrDbObject.MediaType.Game,
                _ => ThemerrDbObject.MediaType.Other,
            };
        }

        public static List<ThemerrData>? LoadFromDisk(string? Path)
        {
            Path ??= Settings.DataFolder + Settings.Filename;

            if (File.Exists(Path))
            {
                return IO.LoadFromDisk<List<ThemerrData>>(Path);
            }
            else return default;
        }

        public static List<ThemerrDbObject> Create(List<string> cleanLogLines)
        {
            List<ThemerrDbObject> dataToAdd = new();

            foreach (string theme in cleanLogLines)
            {
                ThemerrDbObject ThemerrObj = Create(theme);

                if (!dataToAdd.Any(x => x.MediaName == ThemerrObj.MediaName))
                {
                    dataToAdd.Add(ThemerrObj);
                }
            }
            return dataToAdd;
        }

        public static ThemerrDbObject Create(string cleanLogLine)
        {
            string cleanString = Clean(cleanLogLine);

            return new(
                Guid.NewGuid().ToString(),
                GetMediaType(cleanString),
                GetName(cleanString),
                GetTmdbURL(cleanString),
                GetTmdbID(cleanString),
                GetContriURL(cleanString)
                );
        }
    }
}