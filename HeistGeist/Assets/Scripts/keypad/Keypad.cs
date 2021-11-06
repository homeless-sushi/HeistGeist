using UnityEngine;

public class Keypad : MonoBehaviour
{
    private string _rightAnswer;
    private string _answer;
    

    // Start is called before the first frame update
    void Start()
    {
        // TODO Insert right answer first
        _rightAnswer = "";
        _answer = "";
    }

    // Update is called once per frame
    void Update()
    {
        print(GetAnswer());
        
    }

    public void SetRightAnswer(string answer)
    {
        _rightAnswer = answer;
    }
    
    public bool CheckAnswer()
    {
        return _rightAnswer==_answer;
    }
    
    public void SetAnswer(string answer)
    {
        if (!_answer.Contains(answer) && _answer.Length < 4)
        {
            _answer += answer;
        }
        
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
