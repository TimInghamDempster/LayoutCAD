using FluentAssertions;
using LayoutCAD.ViewModel;
using System.Linq;
using Xunit;

namespace LayoutCADTests
{
    public class BackroundGridTests
    {
        private BackgroundGridVM _backgroundVM;

        public BackroundGridTests()
        {
            var compRoot = new VMCompositionRoot();
            _backgroundVM = compRoot.BackgroundGridVM;
        }

        [Fact]
        public void GridLinesScaleWithZoom()
        {
            _backgroundVM.OnMouseWheel(-95.0f);

            _backgroundVM.GridLines.Count().Should().Be(16);
        }
    }
}
