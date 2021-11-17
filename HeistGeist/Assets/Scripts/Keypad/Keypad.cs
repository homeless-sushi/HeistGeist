using System.Collections.Generic;
using UnityEngine;

namespace Keypad
{
    public class Keypad : MonoBehaviour
    {
        private string _rightAnswer;
        private string _currentAnswer = "";
        [SerializeField] private List<NumberButton> numberButtons = new List<NumberButton>(10);

        void Awake()
        {
            // TODO Insert right answer first
            _rightAnswer = "1234";
        }
        
        public void InputNumber(string answer)
        {
            _currentAnswer += answer;
        }
        
        public void SetCode(int[] answer)
        {
            
            _rightAnswer = answer.ToString();
        }

        public void CheckAnswer()
        {
            if (_rightAnswer == _currentAnswer)
            {
                // TODO Trigger Here
                print("Right answer");
                foreach (NumberButton numberButton in numberButtons)
                {
                    numberButton.SetGreen();
                    numberButton.enabled = false;
                }

                //return true;
            }
            else
            {
                print("Wrong answer");
                foreach (NumberButton numberButton in numberButtons)
                {
                    numberButton.SetRed();
                    numberButton.enabled = false;
                }

                //return true;
            }
        }

        public void CancelAnswer()
        {
            _currentAnswer = "";
            foreach (NumberButton numberButton in numberButtons)
            {
                numberButton.SetGrey();
                numberButton.enabled = true;
            }
        }
    }
}