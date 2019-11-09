using System;

namespace LayoutCAD.Model
{
    public interface ICoordinate
    {
        Point Point {get;}
        event Action PointChanged;
    }
}
