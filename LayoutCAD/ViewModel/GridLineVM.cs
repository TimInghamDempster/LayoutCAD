using LayoutCAD.Model;
using System;

namespace LayoutCAD.ViewModel
{
    public class GridLineVM
    {
        public ICoordinate Start { get; }
        public ICoordinate End { get; }

        // We want the user to know where they are in the world, so we label the
        // grid lines with their co-ordinate
        public string Text { get; }
        // Tells us where to draw the label
        public ICoordinate TextPos { get; }

        public GridLineVM(
            CoordinateVM start,
            CoordinateVM end,
            bool isHorizontal,
            Func<(CoordinateVM modelPos, Point offset), OffsetCoordinate> offsetCoordFactory)
        {
            Start = start;
            End = end;

            const int horizontalPad = 10;
            const int verticalPad = 10;

            if (isHorizontal)
            {
                Text = start.ModelSpaceCoordinate.Point.Y.ToString();
                TextPos = offsetCoordFactory((start, new Point { X = horizontalPad, Y = 0 }));
            }
            else
            {
                Text = start.ModelSpaceCoordinate.Point.X.ToString();
                TextPos = offsetCoordFactory((end, new Point { X = 0, Y = -verticalPad }));
            }

            // The 0 labels always look weird, so get rid of them
            if (Text == "0") Text = "";
        }
    }
}
