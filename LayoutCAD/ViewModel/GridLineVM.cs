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

        public GridLineVM(ModelCoordinate start, ModelCoordinate end, bool isHorizontal, double lineSeparation, double gridHeight)
        {
            Start = start;
            End = end;

            const int horizontalPad = 10;
            const int verticalPad = 10;

            if (isHorizontal)
            {
                Text = start.ModelSpaceY.ToString();
                TextPos = 
                    new OffsetCoordinate( 
                        start,
                        new ViewCoordinate(horizontalPad, 0));
            }
            else
            {
                Text = start.ModelSpaceX.ToString();
                TextPos =
                    new OffsetCoordinate(
                        end,
                        new ViewCoordinate(0, -verticalPad));
            }

            // The 0 labels always look weird, so get rid of them
            if (Text == "0") Text = "";
        }
    }
}
