namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Sometimes we want to track a world-space object but with
    /// a view-space offset.  This object does that
    /// </summary>
    public class OffsetCoordinate : ICoordinate
    {
        private readonly WorldCoordinate _worldCoordinate;
        private readonly ViewCoordinate _offset;

        public int ViewSpaceX => _worldCoordinate.ViewSpaceX + _offset.ViewSpaceX;

        public int ViewSpaceY => _worldCoordinate.ViewSpaceY + _offset.ViewSpaceY;

        public OffsetCoordinate(WorldCoordinate worldCoordinate, ViewCoordinate offset)
        {
            this._worldCoordinate = worldCoordinate;
            this._offset = offset;
        }
    }
}
