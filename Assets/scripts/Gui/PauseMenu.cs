using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public AudioSource outside_side;

        void Start()
    {
        outside_side.volume = 0f;
        pauseMenuUI.SetActive(false); // Stellt sicher, dass das Pause-Menü zu Beginn deaktiviert ist
        optionsMenuUI.SetActive(false); // Stellt sicher, dass das Options-Menü zu Beginn deaktiviert ist
        GameIsPaused = false;
    }


    void Update()
    {
        fadeIn();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } 
            else 
            {
                Pause();
            }
        }
    }
    
    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ShowOptions()
    {
        optionsMenuUI.SetActive(true);
    }

    public void HideOptions()
    {
        optionsMenuUI.SetActive(false);
    }
    public void Back2MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Settingsswitch()
    {
        {
            SceneManager.LoadScene(2);
        }
    }

    void fadeIn()
    {
        if (outside_side.volume >= 1f)
        {
            return;
        }
        else
        {
            float newVolume = outside_side.volume + (0.5f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume > 1f)
            {
                newVolume = 1f;
            }
            outside_side.volume = newVolume;
        }
    }
}