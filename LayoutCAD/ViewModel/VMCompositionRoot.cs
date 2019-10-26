namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Composes the ViewModel and Model layers
    /// of the application
    /// </summary>
    public class VMCompositionRoot
    {
        private const double _screenWidth = 900.0;
        private const double _screenHeight = 900.0;

        private readonly ViewPort _viewPort = new ViewPort(_screenWidth, _screenHeight);
        
        public BackgroundGridVM BackgroundGridVM { get; }

        public VMCompositionRoot()
        {
            BackgroundGridVM = new BackgroundGridVM(
                _viewPort,
                (data) =>
                data.isHorizontal ?
                    new GridLineVM(
                        new WorldCoordinate(_viewPort.ModelSpaceLeft, data.modelCoord),
                        new WorldCoordinate(_viewPort.ModelSpaceRight, data.modelCoord),
                        data.isHorizontal,
                        BackgroundGridVM.LineSeparation_mm,
                        _viewPort.ViewHeight) :
                    new GridLineVM(
                        new WorldCoordinate(data.modelCoord, _viewPort.ModelSpaceTop),
                        new WorldCoordinate(data.modelCoord, _viewPort.ModelSpaceBottom),
                        data.isHorizontal,
                        BackgroundGridVM.LineSeparation_mm,
                        _viewPort.ViewHeight));
        }
    }
}
