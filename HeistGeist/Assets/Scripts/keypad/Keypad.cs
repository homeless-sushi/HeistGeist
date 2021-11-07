using System.Collections;
using System.Collections.Generic;
using System.Linq;
using keypad.KeypadState;
using UnityEngine;
using UnityEngine.UI;

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
        
        foreach (var i in Enumerable.Range(1,9))
        {
            _keypadNumberButton.Add(new Number(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var i in Enumerable.Range(1, 9))
        {
            var number = _keypadNumberButton[i - 1];
            var numberObject = GameObject.Find(i.ToString());
            numberObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(number.GetPath());
        }

    }

    public void SetRightAnswer(string answer)
    {
        _rightAnswer = answer;
    }
    
    public void CheckAnswerAndDoAction()
    {
        if (_rightAnswer==_answer)
        {
            // TODO
            print("Enter next puzzle");
            
        }
        else
        {
            // TODO 
            print("Wrong answer");
        }
    }
    
    public void SetAnswer(int answer)
    {
        if (!_answer.Contains(answer.ToString()) && _answer.Length < 4)
        {
            _answer += answer.ToString();
            
            var number = _keypadNumberButton[answer - 1];
            number.ChangeState(new GreenState());
        }

    }
    

    private void CancelAnswer()
    {
        _answer = "";
    }
    
}
