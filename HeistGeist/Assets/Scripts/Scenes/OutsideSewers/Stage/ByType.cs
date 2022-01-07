using UnityEngine;

namespace Scenes.OutsideSewers.Stage
{
    public class ByType : IStage
    {
        private readonly int _tunnelCount;
        private readonly int _exitType;
        
        public ByType(int tunnelCount, TunnelType exitType)
        {
            _tunnelCount = tunnelCount;
            _exitType = (int)exitType;
        }

        public StageExit LoadStage(OutsideSewersController controller)
        {
            var room = controller.LoadRandomRoom(_tunnelCount);
            var exit = new StageExit
            {
                exitType = _exitType,
                exitPosition = Random.Range(0, _tunnelCount)
            };
            room.tunnels[exit.exitPosition].isExit = true;
            room.tunnels[exit.exitPosition].SetSprite(controller.tunnelSprites[_exitType]);
            var j = 0;
            foreach (var i in controller.TunnelTypeSample(_tunnelCount + 1))
            {
                if (i == _exitType)
                    continue;
                if (j == exit.exitPosition)
                    j++;
                room.tunnels[j].isExit = false;
                room.tunnels[j].SetSprite(controller.tunnelSprites[i]);
                j++;
            }
            return exit;
        }
    }
}