using LayoutCAD.Model;
using System;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Defines the size and location of our view of the
    /// world
    /// </summary>
    public class ViewPort
    {
        private readonly Draggable _draggable;

        private Point _location;
        public Point Location => _location - DeltaToModelSpace(_draggable.CurrentOffset);
        public Point Apature { get; private set; }

        public Point ModelSpaceBottomRight => Location + Apature;

        public Point ViewSize { get; }

        internal Point ToViewSpace(Point modelSpacePoint)
        {
            var translated = modelSpacePoint - Location;
            var normalised = Point.ComponentWiseDiv(translated, Apature);
            return Point.ComponentWiseMul(normalised, ViewSize);
        }

        public Point ToModelSpace(Point viewSpacePoint)
        {
            var scaled = DeltaToModelSpace(viewSpacePoint);
            return scaled + Location;
        }

        // Deltas don't have absolute position so the viewport position
        // shouldn't be included in the conversion, only the scaling
        private Point DeltaToModelSpace(Point viewSpaceDelta)
        {

            var normalised = Point.ComponentWiseDiv(viewSpaceDelta, ViewSize);
            var scaled = Point.ComponentWiseMul(normalised, Apature);
            return scaled;
        }

        public ViewPort(Point modelSpaceLocation, Point modelSpaceApature, Draggable draggable)
        {
            Apature = modelSpaceApature;
            _draggable = draggable;
            _location = modelSpaceLocation;
            ViewSize = modelSpaceApature;
        }

        internal void Zoom(float delta)
        {
            // Don't let the apature become negative
            if (delta < 0.0f && (Apature.X < -delta || Apature.Y < -delta)) return;

            Apature += delta;
        }

        internal void StartDrag(double screenX, double screenY)
        {
            _draggable.StartDrag(screenX, screenY);
        }

        internal void Dragging(double screenX, double screenY)
        {
            _draggable.Dragging(screenX, screenY);
        }

        internal void Drop()
        {
            // Negative because we are dragging the model by changing the
            // apature, all other draggables change the model
            _location -= DeltaToModelSpace(_draggable.CurrentOffset);
            _draggable.Drop();
        }
    }
}
