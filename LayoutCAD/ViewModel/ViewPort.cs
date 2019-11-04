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
        private readonly Point _yFlip = new Point(1.0f, -1.0f);

        private Point _location;
        public Point Location => _location - DeltaToModelSpace(_draggable.CurrentOffset);
        public Point Apature { get; private set; }

        public Point ModelSpaceBottomRight => Location + Point.ComponentWiseMul(Apature, _yFlip);

        public Point ViewSize { get; }

        private float _aspectRatio;

        public Point ToViewSpace(Point modelSpacePoint)
        {
            var translated = modelSpacePoint - Location;
            var normalised = Point.ComponentWiseDiv(translated, Apature);
            var rescaled = Point.ComponentWiseMul(normalised, ViewSize);
            return Point.ComponentWiseMul(rescaled, _yFlip);
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
            var flipped = Point.ComponentWiseMul(viewSpaceDelta, _yFlip);
            var normalised = Point.ComponentWiseDiv(flipped, ViewSize);
            var scaled = Point.ComponentWiseMul(normalised, Apature);
            return scaled;
        }

        public ViewPort(Point modelSpaceLocation, Point modelSpaceApature, Draggable draggable)
        {
            Apature = modelSpaceApature;
            _draggable = draggable;
            _location = modelSpaceLocation;
            ViewSize = modelSpaceApature;
            _aspectRatio = modelSpaceApature.X / modelSpaceApature.Y;
        }

        public void Zoom(float delta)
        {
            // Don't let the apature become negative
            if (delta < 0.0f && (Apature.X <= -(delta * _aspectRatio) || Apature.Y <= -delta)) return;

            Point aspectScale = new Point(_aspectRatio, 1.0f);
            Point scaledDelta = aspectScale * delta;

            float zoomFactor = Apature.Y / ViewSize.Y;
            scaledDelta *= zoomFactor;

            Apature += scaledDelta;
            _location -= Point.ComponentWiseMul(scaledDelta, _yFlip) * 0.5f;
        }

        public void StartDrag(double screenX, double screenY)
        {
            _draggable.StartDrag(screenX, screenY);
        }

        public void Dragging(double screenX, double screenY)
        {
            _draggable.Dragging(screenX, screenY);
        }

        public void Drop()
        {
            // Negative because we are dragging the model by changing the
            // apature, all other draggables change the model
            _location -= DeltaToModelSpace(_draggable.CurrentOffset);
            _draggable.Drop();
        }
    }
}
