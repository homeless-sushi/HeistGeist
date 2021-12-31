using UnityEngine;

namespace Scenes.YouWinScreen
{
    public class YouWinAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform scrollUpPanel;
        [SerializeField] private CanvasGroup restartMenu;
            
        void Start()
        {
            scrollUpPanel.gameObject.SetActive(true);
            LeanTween.move(scrollUpPanel, new Vector3(0, -1100, 0), 0);
            LeanTween.move(scrollUpPanel, new Vector3(0, 405, 0), 12f)
                .setEase(LeanTweenType.linear)
                .setOnComplete(
                ()=>
                {
                    restartMenu.gameObject.SetActive(true);
                    LeanTween.alphaCanvas(restartMenu, 0f, 0);
                    LeanTween.alphaCanvas(restartMenu, 1f, 4f)
                        .setEase(LeanTweenType.easeInExpo);
                });
        }
    }
}
