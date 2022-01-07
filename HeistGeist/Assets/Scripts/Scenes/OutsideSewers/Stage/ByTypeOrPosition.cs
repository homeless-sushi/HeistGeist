namespace Scenes.OutsideSewers.Stage
{
    public class ByTypeOrPosition : IStage
    {
        private int _tunnelCount;
        private int _exitType;
        private int _exitPosition;
        
        public ByTypeOrPosition(int tunnelCount, TunnelType exitType, TunnelPosition exitPosition)
        {
            _tunnelCount = tunnelCount;
            _exitType = (int)exitType;
            _exitPosition = (int)exitPosition;
        }
        
        public StageExit LoadStage(OutsideSewersController controller)
        {
            return new StageExit
            {
                exitType = 0,
                exitPosition = 0,
            };
        }
    }
}