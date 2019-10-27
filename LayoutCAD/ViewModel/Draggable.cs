using System;

namespace LayoutCAD.ViewModel
{
    public class Draggable
    {
        private double _dragStartX;
        private double _dragStartY;

        public event Action<(float deltaX, float deltaY)> Dragging;

        public void OnMouseDown(double screenX, double screenY)
        {
            _dragStartX = screenX;
            _dragStartY = screenY;
        }

        public void OnMouseMove(long buttons, double screenX, double screenY)
        {

        }
    }
}
