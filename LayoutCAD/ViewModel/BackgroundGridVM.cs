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
        public Point ViewSize => _viewPort.ViewSize;

        private readonly ViewPort _viewPort;
        private readonly Func<(float modelCoord, bool isHorizontal), GridLineVM> _lineFactory;
        private const int _minTargetMultiplier = 1;
        private const int _maxTargetMultiplier = 5;
        private const float _targetMultiplierConstant = 50.0f;
        private int _gridLineTargetMultiplier;

        // Figure out the spacing in multiples of _lineSeparation
        // required to fill the apature with ~10 lines
        private float CalcLineSpacing(float apature)
        {
            double pow2 = Math.Round(Math.Log(_viewPort.Apature.Y / _viewPort.ViewSize.Y, 2.0));

            return _gridLineTargetMultiplier * _targetMultiplierConstant * (float)Math.Pow(2.0, pow2);
        }

        public IEnumerable<GridLineVM> GridLines
        {
            get
            {
                var lineSpacing = CalcLineSpacing(_viewPort.Apature.Y);
                var linePos = (float)Math.Floor(_viewPort.ModelSpaceBottomRight.Y / lineSpacing) * lineSpacing;
                while (linePos < _viewPort.Location.Y)
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

        public int GridLineTargetMultiplier 
        {
            get { return _gridLineTargetMultiplier; }
            set
            {
                if (value >= _minTargetMultiplier &&
                    value <= _maxTargetMultiplier)
                {
                    _gridLineTargetMultiplier = value;
                }
            }
        }

        public BackgroundGridVM(
            ViewPort viewPort,
            Func<(float modelCoord, bool isHorizontal), GridLineVM> lineFactory)
        {
            _viewPort = viewPort;
            _lineFactory = lineFactory;
            _gridLineTargetMultiplier = 2;
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
