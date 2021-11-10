using System;
using keypad.KeypadState;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace keypad
{
    public class ClickOperation : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
    {
        
        public GameObject keypad;


        // Start is called before the first frame update
        void Start()
        {
            
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            
            var keypadObjectLink = keypad.GetComponent<Keypad>();
            keypadObjectLink.SetAnswer(this.gameObject.name);
            var number = keypadObjectLink.GetKeypadNumberButton()[int.Parse(gameObject.name)];
            number.ChangeState(new GreenState());

        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            
            var keypadObjectLink = keypad.GetComponent<Keypad>();
            
            var number = keypadObjectLink.GetKeypadNumberButton()[int.Parse(gameObject.name)];
            number.ChangeState(new NormalState());
            
        }


        
    }
}
