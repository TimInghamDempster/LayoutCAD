namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Co-ordinate which is set up in World space but
    /// translated to View space for use
    /// </summary>
    public class WorldCoordinate : ICoordinate
    {
        private readonly ViewPort _viewPort;

        private readonly float _modelX;
        private readonly float _modelY;

        public float ViewSpaceX => _viewPort.ToViewSpaceX(_modelX);
        public float ViewSpaceY => _viewPort.ToViewSpaceY(_modelY);

        public WorldCoordinate(float x, float y, ViewPort viewPort)
        {
            _modelX = x;
            _modelY = y;
            _viewPort = viewPort;
        }
    }
}
