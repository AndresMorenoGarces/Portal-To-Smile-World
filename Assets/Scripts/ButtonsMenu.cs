using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public void LoadGameScene()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(Random.Range(3, 6));
    }
    public void LoadStoryScene()
    {
        SceneManager.LoadScene("Story");
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitButton()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Application.Quit();
    }
}
