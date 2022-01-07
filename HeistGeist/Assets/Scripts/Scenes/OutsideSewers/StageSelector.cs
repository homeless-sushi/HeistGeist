using Random = UnityEngine.Random;

namespace Scenes.OutsideSewers
{
    public static class StageSelector
    {
        private static readonly Stage.IStage[][] Stages =
        {
            new Stage.IStage[]
            {
                new Stage.ByPosition(1, TunnelPosition.Left),
                //new Stage.ByTypeOrPosition(2, TunnelType.Muddy, TunnelPosition.Left),
                new Stage.ByPosition(2, TunnelPosition.Center),
                new Stage.ByPosition(3, TunnelPosition.Right),
            },
            new Stage.IStage[]
            {
                new Stage.ByPreviousType(2, 0),
                new Stage.ByPosition(3, TunnelPosition.Center),
                new Stage.ByType(4, TunnelType.Mossy),
            },
            new Stage.IStage[]
            {
                new Stage.ByTypeOrPosition(2, TunnelType.Wet, TunnelPosition.Right),
                new Stage.ByPreviousPosition(3, 0),
                new Stage.ByPreviousPosition(4, 1),
            },
            new Stage.IStage[]
            {
                new Stage.ByPreviousType(2, 1),
                new Stage.ByPreviousType(3, 0),
                new Stage.ByPreviousType(4, 2),
            },
        };

        public static StageExit LoadRandomStage(OutsideSewersController controller)
        {
            var stage = Stages[controller.CurrentStage];
            return stage[Random.Range(0, stage.Length)].LoadStage(controller);
        }
    }
}