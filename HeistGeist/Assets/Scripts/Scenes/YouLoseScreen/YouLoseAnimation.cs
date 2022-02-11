using Manager;
using UnityEngine;

namespace Scenes.YouLoseScreen
{
    public class YouLoseAnimation : MonoBehaviour
    {
    
        [SerializeField] private RectTransform youLosePanel;
        [SerializeField] private CanvasGroup restartMenu;
        
        void Start()
        {
            GameManager.Instance.GameplayStop();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.MenuTrack);

            youLosePanel.gameObject.SetActive(true);
            LeanTween.move(youLosePanel, new Vector3(-16, 600, 0), 0);
            LeanTween.move(youLosePanel, new Vector3(-16, 600, 0), 1f).setOnComplete(
                () =>
                {
                    LeanTween.move(youLosePanel, new Vector3(-16, 600, 0), 0);
                    LeanTween.move(youLosePanel, new Vector3(-16, 102, 0), 2.5f)
                        .setEase(LeanTweenType.easeOutBounce)
                        .setOnComplete(
                            ()=>
                            {
                                restartMenu.gameObject.SetActive(true);
                                LeanTween.alphaCanvas(restartMenu, 0f, 0);
                                LeanTween.alphaCanvas(restartMenu, 1f, 1.5f)
                                    .setEase(LeanTweenType.easeInExpo);
                            });
                });
        }
    }
}
