using System;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Defines the size and location of our view of the
    /// world
    /// </summary>
    public class ViewPort
    {
        public float ModelSpaceTop { get; } = 0.0f;
        public float ModelSpaceBottom => ModelSpaceTop + _apatureY;
        public float ModelSpaceLeft { get; } = 0.0f;
        public float ModelSpaceRight => ModelSpaceLeft + _apatureX;

        private float _apatureX;
        private float _apatureY;

        public float ViewWidth { get; }

        internal float ToViewSpaceX(float modelX)
        {
            return modelX;
        }

        internal float ToViewSpaceY(float modelY)
        {
            return modelY;
        }

        public float ViewHeight { get; }

        public ViewPort(float apatureX, float apatureY)
        {
            _apatureX = apatureX;
            _apatureY = apatureY;
            ViewWidth = apatureX;
            ViewHeight = apatureY;
        }
    }
}
