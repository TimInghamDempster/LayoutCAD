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
        public float Width => _viewPort.ViewWidth;
        public float Height => _viewPort.ViewHeight;

        private readonly ViewPort _viewPort;
        private readonly Func<(float modelCoord, bool isHorizontal), GridLineVM> _lineFactory;

        public IEnumerable<GridLineVM> GridLines
        {
            get
            {
                var viewPortModelHeight = _viewPort.ModelSpaceBottom - _viewPort.ModelSpaceTop;
                var numHorizontalLines = (int)(Math.Ceiling(viewPortModelHeight / LineSeparation_mm));
                var startPosVertical = (float)Math.Floor(_viewPort.ModelSpaceTop / LineSeparation_mm) * LineSeparation_mm;

                for (int i = 0; i < numHorizontalLines; i++)
                {
                    yield return _lineFactory((i * LineSeparation_mm + startPosVertical, true));
                }

                var viewPortModelWidth = _viewPort.ModelSpaceRight - _viewPort.ModelSpaceLeft;
                var numVerticalLines = (int)(Math.Ceiling(viewPortModelWidth / LineSeparation_mm));
                var startPosHorizontal = (float)Math.Floor(_viewPort.ModelSpaceLeft / LineSeparation_mm) * LineSeparation_mm;

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
    }
}
