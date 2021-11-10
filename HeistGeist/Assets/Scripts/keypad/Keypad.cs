using System.Collections.Generic;
using System.Linq;
using keypad.KeypadState;
using UnityEngine;
using UnityEngine.UI;

namespace keypad
{
    public class Keypad : MonoBehaviour
    {
        private string _rightAnswer;
        private string _answer;
        private List<Number> _keypadNumberButton;
    

        // Start is called before the first frame update
        void Start()
        {
            // TODO Insert right answer first
            _rightAnswer = "1234";
            _answer = "";
            _keypadNumberButton = new List<Number>();
        
            foreach (var i in Enumerable.Range(0,10))
            {
                _keypadNumberButton.Add(new Number(i));
            }
        
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var i in Enumerable.Range(0,10))
            {
                var number = _keypadNumberButton[i];
                var numberObject = GameObject.Find(i.ToString());
                numberObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(number.GetPath());
            }
        
        }

        public void SetRightAnswer(string answer)
        {
            _rightAnswer = answer;
        }
    
    
        public void SetAnswer(string answer)
        {
            if (_answer.Length < 4)
            {
                _answer += answer;
            }
        }
    
        public void CheckAnswerAndDoAction()
        {
            if (_rightAnswer==_answer)
            {
                //TODO
                print("Right password, go to next puzzle");
            }
            else
            {
                // TODO 
                print("Wrong answer");
            
                foreach (var i in Enumerable.Range(0,10))
                {
                    var number = _keypadNumberButton[i];
                    number.ChangeState(new RedState());
                }
            
                // CancelAnswer();
            
            }
        }

        public void CancelAnswer()
        {
            _answer = "";
            foreach (var i in Enumerable.Range(0,10))
            {
                var number = _keypadNumberButton[i];
                number.ChangeState(new NormalState());
            }
        
        }


        public List<Number> GetKeypadNumberButton()
        {
            return _keypadNumberButton;
        }


    }
}
