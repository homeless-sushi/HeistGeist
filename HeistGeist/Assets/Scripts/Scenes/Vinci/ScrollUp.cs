using System.Collections;
using UnityEngine;

namespace Scenes.Vinci
{
    public class ScrollUp : MonoBehaviour
    {

        [SerializeField] private RectTransform scrollUp;
        [SerializeField] private CanvasGroup operationButton;
            
        // Start is called before the first frame update
        void Start()
        {
            scrollUp.gameObject.SetActive(true);
            LeanTween.move(scrollUp, new Vector3(0, -1100, 0), 0);
            LeanTween.move(scrollUp, new Vector3(0, 405, 0), 12f)
                .setEase(LeanTweenType.linear)
                .setOnComplete(
                ()=>
                {
                    operationButton.gameObject.SetActive(true);
                    LeanTween.alphaCanvas(operationButton, 0f, 0);
                    LeanTween.alphaCanvas(operationButton, 1f, 4f)
                        .setEase(LeanTweenType.easeInExpo);
                });
        }

        // Update is called once per frame
        void Update()
        {
            
        }

    }
}
