namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Co-ordinate which is set up in World space but
    /// translated to View space for use
    /// </summary>
    public class ModelCoordinate : ICoordinate
    {
        private readonly ViewPort _viewPort;

        public float ModelSpaceX { get; }
        public float ModelSpaceY { get; }

        public float ViewSpaceX => _viewPort.ToViewSpaceX(ModelSpaceX);
        public float ViewSpaceY => _viewPort.ToViewSpaceY(ModelSpaceY);

        public ModelCoordinate(float x, float y, ViewPort viewPort)
        {
            ModelSpaceX = x;
            ModelSpaceY = y;
            _viewPort = viewPort;
        }
    }
}
