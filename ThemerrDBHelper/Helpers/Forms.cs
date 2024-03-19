namespace ThemerrDBHelper.Helpers
{
    public abstract class Forms
    {
        public static int CenterControlX(int parentWidth, int myWidth)
        {
            return (parentWidth - myWidth) / 2;
        }

        public static int CenterControlY(int parentHeight, int myHeight)
        {
            return (parentHeight - myHeight) / 2;
        }

        public static Point GetGlobalLoc(Form f, Point p)
        {
            Point returnP = f.PointToScreen(p);
            returnP.Y += 25;

            return returnP;
        }
    }
}