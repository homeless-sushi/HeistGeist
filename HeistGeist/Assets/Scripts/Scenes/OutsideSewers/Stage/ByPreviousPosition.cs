namespace Scenes.OutsideSewers.Stage
{
    public class ByPreviousPosition : IStage
    {
        private int _tunnelCount;
        private int _previousStage;
        
        public ByPreviousPosition(int tunnelCount, int previousStage)
        {
            _tunnelCount = tunnelCount;
            _previousStage = previousStage;
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