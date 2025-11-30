using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NextLevelName = "Level1";

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(NextLevelName);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
