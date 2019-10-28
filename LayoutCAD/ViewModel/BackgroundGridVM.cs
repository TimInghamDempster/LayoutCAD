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
        private const float _lineSeparation_mm = 150;
        public Point ViewSize => _viewPort.ViewSize;

        private readonly ViewPort _viewPort;
        private readonly Func<(float modelCoord, bool isHorizontal), GridLineVM> _lineFactory;

        // Figure out the spacing in multiples of _lineSeparation
        // required to fill the apature with ~10 lines
        private float CalcLineSpacing(float apature)
        {
            const int targetCount = 10;

            float targetSpacing = apature / targetCount;

            // Quantize the target spacing
            double multiplier = Math.Round(targetSpacing / _lineSeparation_mm);

            double calculatedSpacing = multiplier * _lineSeparation_mm;

            return (float)Math.Max(_lineSeparation_mm, calculatedSpacing);
        }

        public IEnumerable<GridLineVM> GridLines
        {
            get
            {
                var lineSpacing = CalcLineSpacing(_viewPort.Apature.Y);
                var linePos = (float)Math.Floor(_viewPort.ModelSpaceBottomRight.Y / lineSpacing) * lineSpacing;
                while(linePos < _viewPort.Location.Y)
                {
                    linePos += lineSpacing;
                    yield return _lineFactory((linePos, true));
                }

                linePos = (float)Math.Floor(_viewPort.Location.X / lineSpacing) * lineSpacing;
                while (linePos < _viewPort.ModelSpaceBottomRight.X)
                {
                    linePos += lineSpacing;
                    yield return _lineFactory((linePos, false));
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

        public void OnMouseUp()
        {
            _viewPort.Drop();
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
