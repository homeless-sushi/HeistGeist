using Keypad.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.BankOffice.UI
{
    public class UIInspectPainting : MonoBehaviour
    {
        [SerializeField] private Image paintingImage;
        [SerializeField] private Image frameImage;
        
        [SerializeField] private KeypadButtonData rotateButtonData;
        [SerializeField] private Button rotateButton;
        public Button RotateButton => rotateButton;

        [SerializeField] private KeypadButtonData enterButtonData;
        [SerializeField] private Button enterButton;
        public Button EnterButton => enterButton;
        

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

        public void SetPaintingFrameAngle(Sprite painting, Sprite frame, Quaternion rotation)
        {
            paintingImage.sprite = painting;
            paintingImage.transform.rotation = rotation;
            frameImage.sprite = frame;
            frameImage.transform.rotation = rotation;
        }
        
        public void Solved()
        {
            rotateButton.enabled = false;
            rotateButton.image.sprite = rotateButtonData.ButtonGreen;

            enterButton.enabled = false;
            enterButton.image.sprite = enterButtonData.ButtonGreen;
        }
        
        public void Unsolved()
        {
            rotateButton.enabled = true;
            rotateButton.image.sprite = rotateButtonData.ButtonGrey;

            enterButton.enabled = true;
            enterButton.image.sprite = enterButtonData.ButtonGrey;
        }

    }
}