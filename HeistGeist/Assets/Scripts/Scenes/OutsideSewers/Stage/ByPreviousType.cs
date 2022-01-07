namespace Scenes.OutsideSewers.Stage
{
    public class ByPreviousType : IStage
    {
        private int _tunnelCount;
        private int _previousStage;
        
        public ByPreviousType(int tunnelCount, int previousStage)
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