using Keypad.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Keypad
{
    public class UINumberButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
    {
        [SerializeField] private KeypadButtonData keypadButtonData;

        private Button _button;
        [SerializeField] private UIKeypad uiKeypad;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.image.sprite = keypadButtonData.ButtonGrey;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            uiKeypad.InputNumber(keypadButtonData.Number);
            SetGreen();
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            SetGrey();
        }

        
        
        public void SetGrey()
        {
            _button.image.sprite = keypadButtonData.ButtonGrey;
        }
        
        public void SetGreen()
        {
            _button.image.sprite = keypadButtonData.ButtonGreen;
        }

        public void SetRed()
        {
            _button.image.sprite = keypadButtonData.ButtonRed;
        }
        
    }
}