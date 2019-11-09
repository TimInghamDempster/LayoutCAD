using System;
using LayoutCAD.Model;

namespace LayoutCAD.ViewModel
{
    public class PathVM : ViewModelBase
    {
        public ICoordinate[] Coordinates { get; }
        
        public PathVM(Path path, ViewPort viewPort)
        {
            Coordinates = new CoordinateVM[4]
            {
                new CoordinateVM(path.Coordinates[0], viewPort),
                new CoordinateVM(path.Coordinates[1], viewPort),
                new CoordinateVM(path.Coordinates[2], viewPort),
                new CoordinateVM(path.Coordinates[3], viewPort)
            };

            Coordinates[0].PointChanged += OnPointChanged;
            Coordinates[1].PointChanged += OnPointChanged;
            Coordinates[2].PointChanged += OnPointChanged;
            Coordinates[3].PointChanged += OnPointChanged;
        }

        private void OnPointChanged()
        {
            OnPropertyChanged();
        }
    }
}
