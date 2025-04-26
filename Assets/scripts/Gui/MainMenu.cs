
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetInt("FirstTime", 1);
        }
    }
    public void PlayGame()
{
        int fto = PlayerPrefs.GetInt("FirstTime");
        if (fto == 1) { 
            SceneManager.LoadSceneAsync(15); //Changed to dialogue
            PlayerPrefs.SetInt("FirstTime", 0);
        }
        else
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

public void showFullOptions()
    {
        SceneManager.LoadSceneAsync(2);
    }

public void QuitGame(){
   Application.Quit();
}

public void Settingsswitch()
    {
        {
            SceneManager.LoadScene(2);
        }
    }
}
