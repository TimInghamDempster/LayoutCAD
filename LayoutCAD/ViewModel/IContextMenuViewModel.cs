using System.Collections.Generic;

namespace LayoutCAD.ViewModel
{
    public interface IContextMenuViewModel : IMenuItem
    {
        IEnumerable<IMenuItem> MenuItems { get; }
    }
}
