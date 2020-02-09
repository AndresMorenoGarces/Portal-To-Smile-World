using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    private int currentScene = 0; 
    
    public void LoadNextScene()
    {
        switch (currentScene)
        {
            case 3: case 4: case 5:
                SceneManager.LoadScene(Random.Range(6, 9));
                break;
            case 6: case 7: case 8:
                SceneManager.LoadScene(Random.Range(9, 12));
                break;
            case 9: case 10: case 11:
                SceneManager.LoadScene(2);
                break;
            default:
                break;
        }
    }
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

    }
}
