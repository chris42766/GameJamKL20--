using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    
    public GameObject tutorialUI;
    
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (GameisPaused)
        {
            Resume();
        }else
        {
            Pause();
        }
    }    
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
    }

    public void Tutorial()
    {
        
        Debug.Log("Tutorial");
    }

    public void Retry()
    {
        Debug.Log("Retry");
    }
}
