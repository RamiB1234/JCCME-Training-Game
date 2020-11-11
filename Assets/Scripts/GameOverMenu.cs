using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isPaused = false;
    }
}
