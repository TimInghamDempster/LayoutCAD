using LayoutCAD.Model;
using System;
using System.Collections.Generic;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// ViewModel for the background grid, presents height and
    /// width and a collection of all the grid-lines.  Is responsible
    /// for making sure that only the lines actually within the ViewPort
    /// are created
    /// </summary>
    public class BackgroundGridVM
    {
        public float LineSeparation_mm => 150;
        public Point ViewSize => _viewPort.ViewSize;

        private readonly ViewPort _viewPort;
        private readonly Func<(float modelCoord, bool isHorizontal), GridLineVM> _lineFactory;

        public IEnumerable<GridLineVM> GridLines
        {
            get
            {
                var numHorizontalLines = (int)(Math.Ceiling(_viewPort.Apature.Y / LineSeparation_mm));
                var startPosVertical = (float)Math.Floor(_viewPort.Location.Y / LineSeparation_mm) * LineSeparation_mm;
                for (int i = 0; i < numHorizontalLines; i++)
                {
                    yield return _lineFactory((i * LineSeparation_mm + startPosVertical, true));
                }

                var numVerticalLines = (int)(Math.Ceiling(_viewPort.Apature.X / LineSeparation_mm));
                var startPosHorizontal = (float)Math.Floor(_viewPort.Location.X / LineSeparation_mm) * LineSeparation_mm;
                for (int i = 0; i < numVerticalLines; i++)
                {
                    yield return _lineFactory((i * LineSeparation_mm + startPosHorizontal, false));
                }
            }
        }

        public BackgroundGridVM(
            ViewPort viewPort,
            Func<(float modelCoord, bool isHorizontal), GridLineVM> lineFactory)
        {
            _viewPort = viewPort;
            _lineFactory = lineFactory;
        }
        public void OnMouseDown(double screenX, double screenY)
        {
            _viewPort.StartDrag(screenX, screenY);
        }

        public void OnMouseMove(long buttons, double screenX, double screenY)
        {
            if (buttons == 1)
            {
                _viewPort.Dragging(screenX, screenY);
            }
        }

        public void OnMouseWheel(float delta)
        {
            _viewPort.Zoom(delta);
        }
    }
}
