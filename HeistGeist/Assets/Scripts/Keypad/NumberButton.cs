using Keypad.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Keypad
{
    public class NumberButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
    {
        [SerializeField] private KeypadButtonData keypadButtonData;

        private Button _button;
        [SerializeField] private Keypad keypad;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.image.sprite = keypadButtonData.ButtonGrey;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            keypad.InputNumber(keypadButtonData.Number.ToString());
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