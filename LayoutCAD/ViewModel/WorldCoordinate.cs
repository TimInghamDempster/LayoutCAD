namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Co-ordinate which is set up in World space but
    /// translated to View space for use
    /// </summary>
    public class WorldCoordinate : ICoordinate
    {
        public int ViewSpaceX { get; }
        public int ViewSpaceY { get; }

        public WorldCoordinate(double x, double y)
        {
            ViewSpaceX = (int)x;
            ViewSpaceY = (int)y;
        }
    }
}
