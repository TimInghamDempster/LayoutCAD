using LayoutCAD.Model;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Sometimes we want to track a world-space object but with
    /// a view-space offset.  This object does that
    /// </summary>
    public class OffsetCoordinate : ICoordinate
    {
        private readonly Coordinate _worldCoordinate;
        private readonly Coordinate _offset;

        public Point ViewSpacePoint => _worldCoordinate.ViewSpacePoint + _offset.ViewSpacePoint;

        public OffsetCoordinate(Coordinate worldCoordinate, Coordinate offset)
        {
            _worldCoordinate = worldCoordinate;
            _offset = offset;
        }
    }
}
