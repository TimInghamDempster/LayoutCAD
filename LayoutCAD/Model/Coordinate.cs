using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutCAD.Model
{
    public class Coordinate : ICoordinate
    {
        private Point _point;

        public Coordinate(Point initialPoint)
        {
            _point = initialPoint;
        }

        public Point Point
        {
            get { return _point; }
            set
            {
                _point = value;
                PointChanged?.Invoke();
            }
        }

        public event Action? PointChanged;
    }
}
