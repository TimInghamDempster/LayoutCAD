using LayoutCAD.Model;
using System;

namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Composes the ViewModel and Model layers
    /// of the application
    /// </summary>
    public class VMCompositionRoot
    {
        private const float _screenWidth = 1500.0f;
        private const float _screenHeight = 900.0f;

        private readonly ViewPort _viewPort = 
            new ViewPort(
                new Point { X = 0.0f, Y = _screenHeight },
                new Point { X = _screenWidth, Y = _screenHeight },
                new Draggable());
        
        public BackgroundGridVM BackgroundGridVM { get; }

        public LayoutVM LayoutVM { get; }

        public ToolBarVM ToolBarVM { get; }

        public VMCompositionRoot()
        {
            var offsetCoordFactory =
                new Func<(CoordinateVM modelPos, Point offset), OffsetCoordinate>(
                    (args) => 
                    new OffsetCoordinate(
                        args.modelPos,
                        new Coordinate(args.offset)));

            var layout = new Layout(() => new Path());

            LayoutVM = new LayoutVM(
                layout,
                (path) => new PathVM(path, _viewPort));

            BackgroundGridVM = new BackgroundGridVM(
                _viewPort,
                (data) =>
                data.isHorizontal ?
                    new GridLineVM(
                        new CoordinateVM(
                            new Coordinate(new Point { X = _viewPort.Location.X, Y = data.modelCoord }),
                            _viewPort),
                        new CoordinateVM(
                            new Coordinate(new Point { X = _viewPort.ModelSpaceBottomRight.X, Y = data.modelCoord }),
                            _viewPort),
                        data.isHorizontal,
                        offsetCoordFactory) :
                    new GridLineVM(
                        new CoordinateVM(
                            new Coordinate(new Point { X = data.modelCoord, Y = _viewPort.Location.Y }),
                            _viewPort),
                        new CoordinateVM(
                            new Coordinate(new Point { X = data.modelCoord, Y = _viewPort.ModelSpaceBottomRight.Y }),
                            _viewPort),
                        data.isHorizontal,
                        offsetCoordFactory),
                LayoutVM);


            ToolBarVM = new ToolBarVM(BackgroundGridVM);
        }
    }
}
