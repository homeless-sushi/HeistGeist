using System.Collections.Generic;
using System.Linq;
using Manager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Keypad
{
    public class UIKeypad : MonoBehaviour
    {
        [SerializeField] private List<int> _rightAnswer = new List<int>();
        private List<int> _currentAnswer = new List<int>();
        [SerializeField] private List<UINumberButton> numberButtons = new List<UINumberButton>(10);
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button enterButton;

        [SerializeField] private UnityEvent correctAnswer;
        [SerializeField] private UnityEvent wrongAnswer;

        public void InputNumber(int digit)
        {
            _currentAnswer.Add(digit);
        }
        
        public void SetCode(int[] answer)
        {
            _rightAnswer = answer.ToList();
        }

        public void EnterAnswer()
        {
            if (CheckAnswer())
            {
                correctAnswer.Invoke();
                foreach (UINumberButton numberButton in numberButtons)
                {
                    numberButton.SetGreen();
                    numberButton.enabled = false;
                }
                cancelButton.enabled = false;
            }
            else
            {
                wrongAnswer.Invoke();
                foreach (UINumberButton numberButton in numberButtons)
                {
                    numberButton.SetRed();
                    numberButton.enabled = false;
                }
                enterButton.enabled = false;
            }
        }

        public void CancelAnswer()
        {
            _currentAnswer.Clear();
            foreach (UINumberButton numberButton in numberButtons)
            {
                numberButton.SetGrey();
                numberButton.enabled = true;
            }
            enterButton.enabled = true;
        }

        public void Display()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        private bool CheckAnswer()
        {
            bool correct = true;
            for(int i = 0; i < _currentAnswer.Count() && i < _rightAnswer.Count(); i++)
            {
                if (_currentAnswer[i] != _rightAnswer[i])
                    correct = false;
            }

            return correct;
        }
    }
}