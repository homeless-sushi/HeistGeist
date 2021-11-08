using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    public int sceneNumber;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            SceneManager.LoadScene(sceneNumber);
    }
}
