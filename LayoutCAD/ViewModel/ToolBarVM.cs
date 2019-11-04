using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutCAD.ViewModel
{
    public class ToolBarVM
    {
        private readonly BackgroundGridVM _backgroundGridVM;

        public ToolBarVM(BackgroundGridVM backgroundGridVM)
        {
            _backgroundGridVM = backgroundGridVM;
        }

        public void RefineGrid()
        {
            _backgroundGridVM.GridLineSeparationMultiplier--;
        }

        public void CoarsenGrid()
        {
            _backgroundGridVM.GridLineSeparationMultiplier++;
        }
    }
}
