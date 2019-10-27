namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Simple co-ordinate that is setup in View space and returns values
    /// View space
    /// </summary>
    public class ViewCoordinate : ICoordinate
    {
        public float ViewSpaceX { get; }
        public float ViewSpaceY { get; }

        public ViewCoordinate(float x, float y)
        {
            ViewSpaceX = x;
            ViewSpaceY = y;
        }
    }
}
