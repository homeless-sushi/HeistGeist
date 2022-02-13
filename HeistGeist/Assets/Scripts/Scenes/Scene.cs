using UnityEngine;

namespace Scenes
{
    public enum Scene
    {
        StartScreen = 0,
        VaultArt = 1,
        RestartScreen = 2,
        BankLaser = 3,
        PauseScreen = 4,
        BankOffice = 5,
        OutsideSewers = 6,
        YouLoseScreen = 7,
        YouWinScreen = 8,
        OutsideStreet = 9
    }

    public class SceneFlow
    {
        private static int[] _outsideScenes;
        private static Scene[] _bankScenes 
            = {Scene.VaultArt, Scene.BankOffice};
        private static int[] _vaultScenes;

        public static Scene GetRandomOutsideScene()
        {
            return Scene.OutsideSewers;
        }

        public static Scene GetRandomBankScene()
        {
            return _bankScenes[Random.Range(0, _bankScenes.Length)];
        }

        public static Scene GetRandomVaultScene()
        {
            return Scene.BankLaser;
        }

        public void TransitionToOutisideScene()
        {
            
        }
    }
}