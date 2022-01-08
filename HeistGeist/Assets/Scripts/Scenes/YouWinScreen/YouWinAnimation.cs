using Manager;
using UnityEngine;

namespace Scenes.YouWinScreen
{
    public class YouWinAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform scrollUpPanel;
        [SerializeField] private GameObject thankYou;
        [SerializeField] private CanvasGroup restartMenu;
            
        void Start()
        {
            FindObjectOfType<TransitionManager>().TransitionIn();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.MenuTrack);
            
            scrollUpPanel.gameObject.SetActive(true);
            LeanTween.move(scrollUpPanel, new Vector3(0, -590, 0), 0);
            LeanTween.move(scrollUpPanel, new Vector3(0, 390, 0), 15f)
                .setEase(LeanTweenType.linear)
                .setOnComplete(
                ()=>
                {
                    LeanTween.alphaCanvas(scrollUpPanel.gameObject.GetComponent<CanvasGroup>(), 1f, 0);
                    LeanTween.alphaCanvas(scrollUpPanel.gameObject.GetComponent<CanvasGroup>(), 0f, 2f)
                        .setEase(LeanTweenType.easeInExpo).setOnComplete(
                            ()=>{
                                thankYou.gameObject.SetActive(true);
                                LeanTween.alphaCanvas(thankYou.GetComponent<CanvasGroup>(), 0f, 0);
                                LeanTween.alphaCanvas(thankYou.GetComponent<CanvasGroup>(), 1f, 2f)
                                    .setEase(LeanTweenType.easeInExpo).setOnComplete(
                                        ()=>{
                                            restartMenu.gameObject.SetActive(true);
                                            LeanTween.alphaCanvas(restartMenu, 0f, 0);
                                            LeanTween.alphaCanvas(restartMenu, 1f, 4f)
                                                .setEase(LeanTweenType.easeInExpo);
                                        });
                            });
                });
        }
    }
}
