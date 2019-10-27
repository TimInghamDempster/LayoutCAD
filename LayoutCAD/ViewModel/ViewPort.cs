using System;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Defines the size and location of our view of the
    /// world
    /// </summary>
    public class ViewPort
    {
        public float ModelSpaceTop { get; private set; } = 0.0f;
        public float ModelSpaceBottom => ModelSpaceTop + _apatureY;
        public float ModelSpaceLeft { get; private set; } = 0.0f;
        public float ModelSpaceRight => ModelSpaceLeft + _apatureX;

        private float _apatureX;
        private float _apatureY;

        public float ViewWidth { get; }

        internal float ToViewSpaceX(float modelX)
        {
            return (modelX /_apatureX) * ViewWidth;
        }

        internal float ToViewSpaceY(float modelY)
        {
            return (modelY / _apatureY) * ViewHeight;
        }

        public float ViewHeight { get; }

        public ViewPort(float apatureX, float apatureY)
        {
            _apatureX = apatureX;
            _apatureY = apatureY;
            ViewWidth = apatureX;
            ViewHeight = apatureY;
        }

        internal void Zoom(float delta)
        {
            // Don't let the apature become negative
            if (delta < 0.0f && (_apatureX < -delta || _apatureY < -delta)) return;
            
            _apatureX += delta;
            _apatureY += delta;
        }
    }
}
