namespace LayoutCAD.Model
{
    public class Path
    {
        private static float temp = 0.0f;
        public Coordinate[] Coordinates { get; }

        public Path()
        {
            Coordinates = new Coordinate[4]
            {
                new Coordinate(new Point(-110.0f, 10.0f + temp)),
                new Coordinate(new Point(20.0f, 20.0f + temp)),
                new Coordinate(new Point(400.0f, 200.0f + temp)),
                new Coordinate(new Point(500.0f, 100.0f + temp))
            };
            Path.temp += 50.0f;
        }
    }
}
