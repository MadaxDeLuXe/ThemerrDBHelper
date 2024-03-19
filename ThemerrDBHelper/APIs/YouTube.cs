using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using ThemerrDBHelper.Classes;

namespace ThemerrDBHelper.APIs
{
    internal class YouTube
    {
        string _APIKey = string.Empty;

        internal static readonly string[] qryStrings = ["theme", "soundtrack", "score", "ost", "titlesong", "titletrack", "titletheme", "titlescore"];

        internal string APIKey
        {             
            get => _APIKey;
            private set
            {
                if (value.Length == 39)
                {
                    _APIKey = value;
                }
                else
                {
                    //TODO: Errorhandling
                    throw new ArgumentException("Invalid API Key");
                }
            }
        }

        internal YouTube(string APIKey)
        {
            this.APIKey = APIKey;
        }

        internal async Task<List<YouTubeVideo>?> GetYouTubeVideos(string SearchTerm, int qryStringsIndex, int? MaxResultsPerQry = null)
        {
            MaxResultsPerQry ??= Settings.MaxVideoQueue_YT;
            List<YouTubeVideo> Videos = new();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = APIKey,
                ApplicationName = Settings.AppName
            });

            try
            {
                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = $"{SearchTerm} {qryStrings[qryStringsIndex]}";
                searchListRequest.MaxResults = MaxResultsPerQry;

                var searchListResponse = await searchListRequest.ExecuteAsync().ConfigureAwait(false);

                foreach (var res in searchListResponse.Items)
                {
                    if (res.Id.Kind == "youtube#video")
                    {
                        Videos.Add(new YouTubeVideo(res.Snippet.Title, res.Id.VideoId));
                    }
                }
                return Videos ?? default;
            }
            catch (Exception ex)
            {
                //TODO: API limit handling
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
