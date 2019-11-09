using LayoutCAD.Model;
using System;
using System.Collections.Generic;

namespace LayoutCAD.ViewModel
{
    public class LayoutVM : ViewModelBase
    {
        private readonly Layout _layout;
        private readonly Func<Path, PathVM> _pathVMFactory;

        public IEnumerable<PathVM> PathVMs
        {
            get
            {
                foreach(var path in _layout.Paths)
                {
                    yield return _pathVMFactory(path);
                }
            }
        }

        public ICommand AddPathCommand { get; }

        public LayoutVM(Layout layout, Func<Path,PathVM> pathVMFactory)
        {
            _layout = layout;
            _pathVMFactory = pathVMFactory;

            AddPathCommand = new RelayCommand(
                "Add Path",
                () =>
                {
                    _layout.AddPath();
                    OnPropertyChanged();
                },
                () => true);
        }
    }
}
