using FluentAssertions;
using LayoutCAD.Model;
using LayoutCAD.ViewModel;
using Xunit;

namespace LayoutCADTests
{
    public class ViewPortTests
    {
        private ViewPort _viewPort;

        public ViewPortTests()
        {
            _viewPort =
                new ViewPort(
                    new Point(0.0f, 100.0f),
                    new Point(100.0f, 100.0f),
                    new Draggable());
        }

        [Fact]
        public void ViewPortCanScale()
        {
            _viewPort.Zoom(50.0f);

            _viewPort.Apature.X.Should().Be(150.0f);
            _viewPort.Apature.Y.Should().Be(150.0f);

            _viewPort.Location.X.Should().Be(-25.0f);
            _viewPort.Location.Y.Should().Be(125.0f);
        }

        [Fact]
        public void ViewPortCanDrag()
        {
            _viewPort.StartDrag(10.0, 10.0);

            _viewPort.Dragging(50.0, -35.0);

            _viewPort.Location.X.Should().Be(-40.0f);
            _viewPort.Location.Y.Should().Be(55.0f);
        }

        [Fact]
        public void ViewPortCanDrop()
        {
            _viewPort.StartDrag(15.0, 1.0);

            _viewPort.Dragging(5.0, -31.0);

            _viewPort.Drop();

            _viewPort.Location.X.Should().Be(10.0f);
            _viewPort.Location.Y.Should().Be(68.0f);
        }

        [Fact]
        public void ViewPortDoesntZoomBelowZero()
        {
            _viewPort.Zoom(-150.0f);

            _viewPort.Apature.X.Should().Be(100.0f);
            _viewPort.Apature.Y.Should().Be(100.0f);
        }

        [Fact]
        public void ViewPortConvertsModelToViewSpace()
        {
            _viewPort.Zoom(-50.0f);
            _viewPort.StartDrag(0.0, 0.0);
            _viewPort.Dragging(15, 20);
            _viewPort.Drop();

            var testModelPoint = new Point( 10.0f, 20.0f );

            var viewPoint = _viewPort.ToViewSpace(testModelPoint);

            viewPoint.X.Should().Be(-15.000001f);
            viewPoint.Y.Should().Be(130.0f);
        }
        [Fact]
        public void ViewPortConvertsViewToModelSpace()
        {
            _viewPort.Zoom(-50.0f);
            _viewPort.StartDrag(0.0, 0.0);
            _viewPort.Dragging(15, 20);
            _viewPort.Drop();

            var testModelPoint = new Point(10.0f, 20.0f);

            var viewPoint = _viewPort.ToModelSpace(testModelPoint);

            viewPoint.X.Should().Be(22.5f);
            viewPoint.Y.Should().Be(75.0f);
        }
    }
}
