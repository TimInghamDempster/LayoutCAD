using LayoutCAD.Model;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Tracks an object as it gets dragged around, handles a bunch
    /// of boilerplate that would get repetitive because we don't
    /// get relative mouse coords on a mousemove for some reason
    /// </summary>
    public class Draggable
    {
        private Point _dragStart;
        public Point CurrentOffset { get; private set; }

        public void StartDrag(double screenX, double screenY)
        {
            _dragStart = new Point { X = (float)screenX, Y = (float)screenY };
        }

        internal void Dragging(double screenX, double screenY)
        {
            var currentLocation = new Point { X = (float)screenX, Y = (float)screenY };
            CurrentOffset = currentLocation - _dragStart;
        }

        public void Drop()
        {
            CurrentOffset = Point.Zero;
        }
    }
}
