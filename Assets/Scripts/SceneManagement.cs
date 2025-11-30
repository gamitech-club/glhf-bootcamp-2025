using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Test Player");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
