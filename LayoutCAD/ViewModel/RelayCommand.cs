using System;

namespace LayoutCAD.ViewModel
{
    public class RelayCommand : ICommand
    {
        public Action Execute { get; }

        public Func<bool> CanExecute { get; }

        public string ContextMenuName { get; }

        public RelayCommand(string name, Action execute, Func<bool> canExecute)
        {
            ContextMenuName = name;
            Execute = execute;
            CanExecute = canExecute;
        }
    }
}
