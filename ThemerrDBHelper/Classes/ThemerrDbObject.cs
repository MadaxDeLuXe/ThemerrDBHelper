using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemerrDBHelper.Classes
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ThemerrDbObject
    {
        public static event EventHandler? SelectedVideoChanged;

        public enum MediaType { Movie, TVShow, Game, Other }

        #region private
        [JsonProperty]
        List<YouTubeVideo>? _PossibleVideos = new();
        [JsonIgnore]
        YouTubeVideo? _currentVideoSelection = null;
        [JsonProperty]
        YouTubeVideo? _savedVideo = null;
        #endregion

        public string Id { get; private set; }

        public MediaType Type { get; private set; }
        public string MediaName { get; private set; }
        public string TmdbURL { get; private set; }
        public string TmdbID { get; private set; }
        public string ContriURL { get; private set; }
        public bool IsReported { get; set; } = false;

        [JsonIgnore]
        public List<YouTubeVideo>? PossibleVideos
        {
            get => _PossibleVideos;
            set
            {
                _PossibleVideos = value;
            }
        }
        [JsonIgnore]
        public YouTubeVideo? currentVideoSelection
        {
            get => _currentVideoSelection;
            set
            {
                if (value != null)
                {
                    _currentVideoSelection = value;
                    SelectedVideoChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        [JsonIgnore]
        public YouTubeVideo? YouTubeVideo
        {
            get => _savedVideo;
            set
            {
                if (value != null)
                {
                    _savedVideo = value;
                }
            }
        }


        public ThemerrDbObject(string Id, MediaType Type, string MediaName, string TmdbURL, string TmdbID, string ContriURL)
        {
            this.Id = Id;
            this.Type = Type;
            this.MediaName = MediaName;
            this.TmdbURL = TmdbURL;
            this.TmdbID = TmdbID;
            this.ContriURL = ContriURL;
        }
    }
}
