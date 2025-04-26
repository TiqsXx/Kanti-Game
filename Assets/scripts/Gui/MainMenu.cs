
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        if (PlayerPrefs.GetString("FirstTime") is null || PlayerPrefs.GetString("FirstTime") == "true")
        {
            PlayerPrefs.SetString("FirstTime", "true");
            Debug.Log(PlayerPrefs.GetInt("FirstTime"));
        }
    }
    public void PlayGame()
    {
        string fto = PlayerPrefs.GetString("FirstTime");
        if (fto == "true")
        {
            PlayerPrefs.SetString("FirstTime", "false");
            SceneManager.LoadSceneAsync(15, LoadSceneMode.Single); //Changed to dialogue
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settingsswitch()
    {
        {
            SceneManager.LoadScene(2);
        }
    }

    public void ShowDialogue()
    {
        string[] allkeys = { "Phy1Completed", "Math1Completed", "Mus1Completed", "Eng1Completed", "Deu1Completed"};
        foreach (string key in allkeys)
        {
            PlayerPrefs.SetString(key, "false");
        }
        PlayerPrefs.SetString("FirstTime", "true");
    }
}
