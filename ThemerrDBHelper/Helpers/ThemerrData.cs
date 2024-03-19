using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            switch (s.Substring(s.IndexOf('[') + 1, s.IndexOf(']') - s.IndexOf('[') - 1))
            {
                case "MOVIE":
                    return ThemerrDbObject.MediaType.Movie;

                case "TV SHOW":
                    return ThemerrDbObject.MediaType.TVShow;

                case "GAME":
                    return ThemerrDbObject.MediaType.Game;

                default:
                    return ThemerrDbObject.MediaType.Other;
            }
        }
    }
}
