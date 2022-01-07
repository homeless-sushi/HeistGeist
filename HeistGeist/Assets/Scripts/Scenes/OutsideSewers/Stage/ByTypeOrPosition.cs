namespace Scenes.OutsideSewers.Stage
{
    public class ByTypeOrPosition : IStage
    {
        private readonly int _tunnelCount;
        private readonly int _exitType;
        private readonly int _exitPosition;
        
        public ByTypeOrPosition(int tunnelCount, TunnelType exitType, TunnelPosition exitPosition)
        {
            _tunnelCount = tunnelCount;
            _exitType = (int)exitType;
            _exitPosition = (int)exitPosition;
        }
        
        public StageExit LoadStage(OutsideSewersController controller)
        {
            var room = controller.LoadRandomRoom(_tunnelCount);
            var exit = new StageExit
            {
                exitPosition = _exitPosition
            };
            var defaultPositionType = 0;
            var found = false;
            var j = 0;
            foreach (var i in controller.TunnelTypeSample(_tunnelCount))
            {
                room.tunnels[j].SetSprite(controller.tunnelSprites[i]);
                if (!found)
                {
                    if (i == _exitType)
                    {
                        exit.exitType = i;
                        exit.exitPosition = j;
                        room.tunnels[j].isExit = true;
                        found = true;
                    }
                    else {
                        room.tunnels[j].isExit = false;
                        if(j == _exitPosition)
                            defaultPositionType = i;
                    }
                }
                j++;
            }
            if (!found)
            {
                exit.exitType = defaultPositionType;
                room.tunnels[_exitPosition].isExit = true;
            }
            return exit;
        }
    }
}