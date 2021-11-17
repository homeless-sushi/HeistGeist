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
            if (!keypad.activeSelf)
            {
                keypad.SetActive(true);
            }
            else
            {
                keypad.GetComponent<Keypad.Keypad>().CancelAnswer();
                keypad.SetActive(false);
            }

        }
    }
}
