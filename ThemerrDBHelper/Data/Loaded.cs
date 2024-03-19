namespace ThemerrDBHelper.Data
{
    public static class Loaded
    {
        public static event EventHandler? ThemerrObjectsAdded;
        public static event EventHandler? SelectedThemerrObjectChanged;

        static List<Classes.ThemerrDbObject> _ThemerrObjects = [];
        static Classes.ThemerrDbObject? _selectedObject = null;

        public static List<Classes.ThemerrDbObject> MissingThemerrObjects
        {
            get => _ThemerrObjects;
            internal set
            {
                foreach (Classes.ThemerrDbObject data in value)
                {
                    if (!_ThemerrObjects.Any(x => x.MediaName == data.MediaName))
                    {
                        _ThemerrObjects.Add(data);
                    }
                }
                MissingThemerrObjects.Sort((x, y) => x.MediaName.CompareTo(y.MediaName));
                ThemerrObjectsAdded?.Invoke("Data.Loaded", EventArgs.Empty);
            }
        }

        public static Classes.ThemerrDbObject? SelectedObject
        {
            get => _selectedObject;            
            set
            {
                if (value != null)
                {
                    _selectedObject = value;
                    _selectedObject.currentVideoSelection = value.YouTubeVideo ?? value.PossibleVideos?.FirstOrDefault();

                    SelectedThemerrObjectChanged?.Invoke("Data.Loaded", EventArgs.Empty);
                }
            }
        }
    }
}
