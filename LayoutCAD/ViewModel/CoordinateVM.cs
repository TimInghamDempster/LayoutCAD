using System;
using LayoutCAD.Model;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Co-ordinate which is set up in World space but
    /// translated to View space for use
    /// </summary>
    public class CoordinateVM : ICoordinate
    {
        private readonly ViewPort _viewPort;

        private Point _cachedModelSpacePoint;

        public event Action? PointChanged;

        public Coordinate ModelSpaceCoordinate { get; }
        public Point Point
        {
            get
            {
                // Can't cache this as the value can change externally
                // (i.e. if the user moves the viewport)
                return _viewPort.ToViewSpace(ModelSpaceCoordinate.Point);
            }
            set
            {
                ModelSpaceCoordinate.Point = _viewPort.ToModelSpace(value);
            }
        }

        public CoordinateVM(
            Coordinate coordinate,
            ViewPort viewPort)
        {
            _viewPort = viewPort;
            ModelSpaceCoordinate = coordinate;
            _cachedModelSpacePoint = ModelSpaceCoordinate.Point;

            ModelSpaceCoordinate.PointChanged += OnPointChanged;
            viewPort.ViewPortChanged += OnViewPortChanged;
        }

        private void OnViewPortChanged()
        {
            PointChanged?.Invoke();
        }

        private void OnPointChanged()
        {
            if(ModelSpaceCoordinate.Point != _cachedModelSpacePoint)
            {
                PointChanged?.Invoke();
            }
        }
    }
}
