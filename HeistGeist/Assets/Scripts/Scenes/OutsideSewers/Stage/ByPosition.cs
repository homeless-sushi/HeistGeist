namespace Scenes.OutsideSewers.Stage
{
    public class ByPosition : IStage
    {
        private readonly int _tunnelCount;
        private readonly int _exitPosition;
        
        public ByPosition(int tunnelCount, TunnelPosition exitPosition)
        {
            _tunnelCount = tunnelCount;
            _exitPosition = (int)exitPosition;
        }
        
        public StageExit LoadStage(OutsideSewersController controller)
        {
            var room = controller.LoadRandomRoom(_tunnelCount);
            var exit = new StageExit
            {
                exitPosition = _exitPosition
            };
            var j = 0;
            foreach (var i in controller.TunnelTypeSample(_tunnelCount))
            {
                if (j == _exitPosition)
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