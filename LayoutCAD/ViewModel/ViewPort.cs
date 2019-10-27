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
        public Point Location { get; private set; }
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
            var normalised = Point.ComponentWiseDiv(viewSpacePoint, ViewSize);
            var scaled = Point.ComponentWiseMul(normalised, Apature);
            return scaled + Location;
         }

        public ViewPort(Point modelSpaceLocation, Point modelSpaceApature)
        {
            Apature = modelSpaceApature;
            Location = modelSpaceLocation;
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
            throw new NotImplementedException();
        }

        internal void Dragging(double screenX, double screenY)
        {
            throw new NotImplementedException();
        }
    }
}
