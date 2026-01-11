using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadPlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
