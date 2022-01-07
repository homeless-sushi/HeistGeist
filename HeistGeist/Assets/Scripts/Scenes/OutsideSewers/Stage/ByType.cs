namespace Scenes.OutsideSewers.Stage
{
    public class ByType : IStage
    {
        private int _tunnelCount;
        private int _exitType;
        
        public ByType(int tunnelCount, TunnelType exitType)
        {
            _tunnelCount = tunnelCount;
            _exitType = (int)exitType;
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