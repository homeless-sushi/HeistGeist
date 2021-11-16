using UnityEngine;
using UnityEngine.UI;

namespace Scenes.VaultArt.UI
{
    public class UIInspectPainting : MonoBehaviour
    {
        [SerializeField] private Image paintingImage;
        [SerializeField] private Image frameImage;
        [SerializeField] private Image codeNumberImage;

        private void Awake()
        {
            paintingImage.preserveAspect = true;
            frameImage.preserveAspect = true;
        }
        
        public void Display()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void SetPainting(Sprite painting)
        {
            paintingImage.sprite = painting;
        }
        public void SetFrame(Sprite frame)
        {
            frameImage.sprite = frame;
        }
        public void SetCodeNumber(Sprite codeNumber)
        {
            codeNumberImage.sprite = codeNumber;
        }
    }
}