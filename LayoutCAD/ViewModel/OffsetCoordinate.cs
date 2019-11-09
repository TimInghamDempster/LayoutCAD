using System;
using LayoutCAD.Model;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Sometimes we want to track a world-space object but with
    /// a view-space offset.  This object does that
    /// </summary>
    public class OffsetCoordinate : ICoordinate
    {
        private readonly CoordinateVM _worldCoordinate;
        private readonly Coordinate _offset;

        public event Action? PointChanged;

        public Point Point => _worldCoordinate.Point + _offset.Point;


        public OffsetCoordinate(CoordinateVM worldCoordinate, Coordinate offset)
        {
            _worldCoordinate = worldCoordinate;
            _offset = offset;
            _worldCoordinate.PointChanged += OnPointChanged;
        }

        private void OnPointChanged()
        {
            PointChanged?.Invoke();
        }
    }
}
