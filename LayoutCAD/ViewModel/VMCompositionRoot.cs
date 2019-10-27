namespace LayoutCAD.ViewModel
{
    /// <summary>
    /// Composes the ViewModel and Model layers
    /// of the application
    /// </summary>
    public class VMCompositionRoot
    {
        private const float _screenWidth = 900.0f;
        private const float _screenHeight = 900.0f;

        private readonly ViewPort _viewPort = new ViewPort(_screenWidth, _screenHeight);
        
        public BackgroundGridVM BackgroundGridVM { get; }

        public VMCompositionRoot()
        {
            BackgroundGridVM = new BackgroundGridVM(
                _viewPort,
                (data) =>
                data.isHorizontal ?
                    new GridLineVM(
                        new ModelCoordinate(_viewPort.ModelSpaceLeft, data.modelCoord, _viewPort),
                        new ModelCoordinate(_viewPort.ModelSpaceRight, data.modelCoord, _viewPort),
                        data.isHorizontal,
                        BackgroundGridVM.LineSeparation_mm,
                        _viewPort.ViewHeight) :
                    new GridLineVM(
                        new ModelCoordinate(data.modelCoord, _viewPort.ModelSpaceTop, _viewPort),
                        new ModelCoordinate(data.modelCoord, _viewPort.ModelSpaceBottom, _viewPort),
                        data.isHorizontal,
                        BackgroundGridVM.LineSeparation_mm,
                        _viewPort.ViewHeight));
        }
    }
}
