using System;

namespace LayoutCAD.ViewModel
{
    public interface ICommand : IMenuItem
    {
        Action Execute { get; }
        Func<bool> CanExecute { get; }
    }
}
