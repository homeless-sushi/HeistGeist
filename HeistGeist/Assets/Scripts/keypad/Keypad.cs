using UnityEngine;

public class Keypad : MonoBehaviour
{
    private string _rightAnswer;
    private string _answer;
    

    // Start is called before the first frame update
    void Start()
    {
        // TODO Insert right answer first
        _rightAnswer = "1234";
        _answer = "";
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
    public void SetAnswer(string answer)
    {
        if (!_answer.Contains(answer) && _answer.Length < 4)
        {
            _answer += answer;
        }
        
        print(GetAnswer());
        
    }
    
    public string GetAnswer()
    {
        return _answer;
    }

    public void CancelAnswer()
    {
        _answer = "";
    }
    
}
