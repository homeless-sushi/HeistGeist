using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Manager
{
    public class TransitionManager : MonoBehaviour
    {
        private static string _transitionText = null;
    
        [SerializeField] private CanvasGroup transitionCanvasGroup;
        [SerializeField] private TextMeshProUGUI transitionUIText;
        [SerializeField] private RectTransform startQuitTransitionFader;

        public void TransitionIn()
        {
            transitionCanvasGroup.gameObject.SetActive(true);
        
            transitionUIText.text = _transitionText ?? "";
            LeanTween.alphaCanvas(transitionCanvasGroup, 1f, 0);
            LeanTween.alphaCanvas(transitionCanvasGroup, 0f, 1.5f)
                .setEase(LeanTweenType.easeInOutExpo)
                .setOnComplete(
                    () =>
                    {
                        transitionCanvasGroup.gameObject.SetActive(false);
                    });
        
            _transitionText = null;
        }
    
        public void TransitionOut([CanBeNull] string transitionText, Action onTransitionEnd)
        {
        
            transitionCanvasGroup.gameObject.SetActive(true);
        
            transitionUIText.text = transitionText;
            _transitionText = transitionText;
        
            LeanTween.alphaCanvas(transitionCanvasGroup, 0f, 0);
            LeanTween.alphaCanvas(transitionCanvasGroup, 1f, 1.5f)
                .setEase(LeanTweenType.easeInOutExpo)
                .setOnComplete(onTransitionEnd);
        }
    
        public void StartTransition(Action onTransitionEnd)
        {
            startQuitTransitionFader.gameObject.SetActive(true);
            LeanTween.scale(startQuitTransitionFader,new Vector3(1, 1, 1), 0);
            LeanTween.scale(startQuitTransitionFader, Vector3.zero, 1.5f)
                .setEase(LeanTweenType.easeInOutExpo)
                .setOnComplete(
                    ()=>
                    {
                        startQuitTransitionFader.gameObject.SetActive(false);
                        onTransitionEnd?.Invoke();
                    });
        }
    
        public void QuitTransition(Action onTransitionEnd)
        {
            startQuitTransitionFader.gameObject.SetActive(true);
            LeanTween.scale(startQuitTransitionFader,Vector3.zero, 0f);
            LeanTween.scale(startQuitTransitionFader, new Vector3(1, 1, 1), 1.5f)
                .setEase(LeanTweenType.easeInOutExpo)
                .setOnComplete(
                    ()=>
                    {
                        startQuitTransitionFader.gameObject.SetActive(false);
                        onTransitionEnd?.Invoke();
                    });
        }
    }
}
