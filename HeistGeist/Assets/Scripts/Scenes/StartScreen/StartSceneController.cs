using Manager;
using UnityEngine;

namespace Scenes.StartScreen
{
    public class StartSceneController : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.GameplayStop();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.MenuTrack);
        }
    }
}
