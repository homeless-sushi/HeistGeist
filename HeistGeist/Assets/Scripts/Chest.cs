using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject keypad;
    
    
    private void Start()
    {
        keypad.SetActive(false);
    }
    
    
    public void OnInteract()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keypad.SetActive(true);
        }
    }
}
