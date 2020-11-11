using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
