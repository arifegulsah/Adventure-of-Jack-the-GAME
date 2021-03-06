using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Bu script sayesinde esc ile oyun durdurulduğu zaman Canvas üzerine oluşturduğum panel etkinleşecek.

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;

    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;

    }

    public void OpenSettingsMenu()
    {
        settingsWindow.SetActive(true); 
    }

    public void CloseSettingsMenu()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
