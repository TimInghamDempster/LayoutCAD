namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Defines the size and location of our view of the
    /// world
    /// </summary>
    public class ViewPort
    {
        public double ModelSpaceTop { get; } = 0.0;
        public double ModelSpaceBottom { get; }
        public double ModelSpaceLeft { get; } = 0.0;
        public double ModelSpaceRight { get; }

        public int ViewWidth { get; }
        public int ViewHeight { get; }

        public ViewPort(double rightCoord, double bottomCoord)
        {
            ModelSpaceRight = rightCoord;
            ModelSpaceBottom = bottomCoord;
            ViewWidth = (int)rightCoord;
            ViewHeight = (int)bottomCoord;
        }
    }
}
