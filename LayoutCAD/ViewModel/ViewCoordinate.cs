namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Simple co-ordinate that is setup in View space and returns values
    /// View space
    /// </summary>
    public class ViewCoordinate : ICoordinate
    {
        public int ViewSpaceX { get; }
        public int ViewSpaceY { get; }

        public ViewCoordinate(int x, int y)
        {
            ViewSpaceX = x;
            ViewSpaceY = y;
        }
    }
}
