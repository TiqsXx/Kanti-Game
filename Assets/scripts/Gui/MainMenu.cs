
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

public void PlayGame()
{
    SceneManager.LoadSceneAsync(13); //Changed to dialogue
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
