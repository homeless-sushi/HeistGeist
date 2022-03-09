using System.Runtime.InteropServices;
using UnityEngine;

namespace Scenes.OutsideSewers.Stage
{
    public class ByPreviousType : IStage
    {
        private readonly int _tunnelCount;
        private readonly int _previousStage;
        
        public ByPreviousType(int tunnelCount, int previousStage)
        {
            _tunnelCount = tunnelCount;
            _previousStage = previousStage;
        }
        
        public StageExit LoadStage(OutsideSewersController controller)
        {
            var room = controller.LoadRandomRoom(_tunnelCount);
            Debug.Log(room.tunnels.Length);
            var exit = new StageExit
            {
                exitType = controller.GetStageExit(_previousStage).exitType,
                exitPosition = Random.Range(0, _tunnelCount)
            };
            room.tunnels[exit.exitPosition].isExit = true;
            room.tunnels[exit.exitPosition].SetSprite(controller.tunnelSprites[exit.exitType]);
            var j = 0;
            foreach (var i in controller.TunnelTypeSample(_tunnelCount + 1))
            {
                if (j >= room.tunnels.Length)
                    break;
                if (i == exit.exitType)
                    continue;
                if (j == exit.exitPosition)
                {
                    j++;
                    continue;
                }
                room.tunnels[j].isExit = false;
                room.tunnels[j].SetSprite(controller.tunnelSprites[i]);
                j++;
            }
            return exit;
        }
    }
}