using Scenes.VaultArt;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    public int sceneNumber;
    public Door door;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            SceneManager.LoadScene(sceneNumber);

        if (Input.GetKeyDown(KeyCode.D))
            door.Open();
    }
}
