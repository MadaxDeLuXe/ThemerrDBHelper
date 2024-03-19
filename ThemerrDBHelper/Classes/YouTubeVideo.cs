using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemerrDBHelper.Classes
{
    public class YouTubeVideo
    {
        public string Title { get; set; }
        public string VideoId { get; set; }

        public Uri Uri
        {
            get
            {
                return new Uri($"https://www.youtube.com/embed/{VideoId}");
            }
        }

        public YouTubeVideo(string Title, string VideoId)
        {
            this.Title = Title;
            this.VideoId = VideoId;
        }
    }
}
