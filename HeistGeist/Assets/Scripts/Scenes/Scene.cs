﻿namespace Scenes
{
    public enum Scene
    {
        StartScreen = 0,
        VaultArt = 1,
        RestartScreen = 2,
        BankLaser = 3,
        PauseScreen = 4,
    }

    public class SceneFlow
    {
        private static int[] _outsideScenes;
        private static int[] _bankScenes;
        private static int[] _vaultScenes;

        public static Scene GetRandomOutsideScene()
        {
            return Scene.BankLaser;
        }

        public static Scene GetRandomBankScene()
        {
            return Scene.BankLaser;
        }

        public static Scene GetRandomVaultScene()
        {
            return Scene.VaultArt;
        }

        public void TransitionToOutisideScene()
        {
            
        }
    }
}