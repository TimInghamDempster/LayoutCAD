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

            _backgroundVM.GridLines.Count().Should().Be(24);
        }

        [Fact]
        public void GridHasMinSpacing()
        {
            _backgroundVM.OnMouseWheel(-95.0f);

            for (int i = 0; i < 100; i++)
            {
                _backgroundVM.GridLineTargetMultiplier--;
            }

            _backgroundVM.GridLines.Count().Should().Be(46);
        }
        
        [Fact]
        public void GridHasMaxSapcing()
        {
            _backgroundVM.OnMouseWheel(-95.0f);

            for (int i = 0; i < 100; i++)
            {
                _backgroundVM.GridLineTargetMultiplier++;
            }

            _backgroundVM.GridLines.Count().Should().Be(10);
        }
    }
}
