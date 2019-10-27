using LayoutCAD.Model;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Co-ordinate which is set up in World space but
    /// translated to View space for use
    /// </summary>
    public class Coordinate : ICoordinate
    {
        private readonly ViewPort _viewPort;

        private Point _modelSpacePoint;
        public Point ModelSpacePoint 
        { 
            get
            {
                return _modelSpacePoint;
            }
            set
            {
                _modelSpacePoint = value;
            }
        }
        public Point ViewSpacePoint
        {
            get
            {
                // Can't cache this as the value can change externally
                // (i.e. if the user moves the viewport)
                return _viewPort.ToViewSpace(_modelSpacePoint);
            }
            set
            {
                _modelSpacePoint = _viewPort.ToModelSpace(value);
            }
        }

        public Coordinate(Point initialPoint, bool initialPointModelSpace, ViewPort viewPort)
        {
            // Initialise BEFORE the points, because they
            // use this
            _viewPort = viewPort;

            if (initialPointModelSpace)
            {
                ModelSpacePoint = initialPoint;
            }
            else
            {
                ViewSpacePoint = initialPoint;
            }
        }
    }
}
