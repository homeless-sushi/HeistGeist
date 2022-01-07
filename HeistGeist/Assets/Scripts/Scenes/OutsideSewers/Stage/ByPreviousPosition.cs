using UnityEngine;

namespace Scenes.OutsideSewers.Stage
{
    public class ByPreviousPosition : IStage
    {
        private readonly int _tunnelCount;
        private readonly int _previousStage;
        
        public ByPreviousPosition(int tunnelCount, int previousStage)
        {
            _tunnelCount = tunnelCount;
            _previousStage = previousStage;
        }
        
        public StageExit LoadStage(OutsideSewersController controller)
        {
            var room = controller.LoadRandomRoom(_tunnelCount);
            var exit = new StageExit
            {
                exitPosition = controller.GetStageExit(_previousStage).exitPosition
            };
            var j = 0;
            foreach (var i in controller.TunnelTypeSample(_tunnelCount))
            {
                if (j == exit.exitPosition)
                {
                    exit.exitType = i;
                    room.tunnels[j].isExit = true;
                }
                else
                {
                    room.tunnels[j].isExit = false;
                }
                room.tunnels[j].SetSprite(controller.tunnelSprites[i]);
                j++;
            }
            return exit;
        }
    }
}