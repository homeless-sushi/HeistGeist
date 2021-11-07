using System.Collections;
using System.Collections.Generic;
using keypad.KeypadState;
using UnityEngine;

public class Number
{
    private KeyState _keyState;
    private readonly int _imageNumber;
    private string _imagePath;
    
    
    public Number(int buttonNumber)
    {
        _keyState = new NormalState();
        _imageNumber = buttonNumber;
        ChangePath();
    }

    
    public void ChangeState(KeyState newState)
    {
        _keyState = newState;
        ChangePath();
    }

    public string GetPath()
    {
        ChangePath();
        return _imagePath;
    }

    private void ChangePath()
    {
        // _imagePath = "Assets/Keypad/" + _keyState.GetColor() + _imageNumber + ".png";
        _imagePath = "Keypad/" + _keyState.GetColor() + _imageNumber;
    }
    
}
