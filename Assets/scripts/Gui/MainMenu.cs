
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image background;
    public void Start()
    {
        //animateBackground();
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
        string[] allkeys = { "Phy1Completed", "Math1Completed", "Mus1Completed", "Eng1Completed", "Deu1Completed", "Inf1Completed", "Geo1Completed", "Fra1Completed", "Ges1Completed" };
        string[] allscores = { "ScorePhy1", "ScoreMath1", "ScoreMus1", "ScoreEng1", "ScoreDeu1", "ScoreInf1", "ScoreGeo1", "ScoreFra1", "ScoreGes1" };
        foreach (string key in allkeys)
        {
            PlayerPrefs.SetString(key, "false");
        }
        foreach (string score in allscores)
        {
            PlayerPrefs.DeleteKey(score);
        }
        PlayerPrefs.SetString("FirstTime", "true");
    }

    void animateBackground()
    {
        int r, g, b;
        int counter = 0;
        bool addred, addblue, addgreen;
        addred = true;
        addblue = true;
        addgreen = true;
        r = Random.Range(0, 255);
        g = Random.Range(0, 255);
        b = Random.Range(0, 255);
        Debug.Log(r + " " + g + " " + b);
        while (counter < 1000)
        {
            if (r < 255 && addred == true)
            {
                r += 1;
            }
            else
            {
                addred = false;
                r -= 1;
            }
            if (g < 255)
            {
                g += 1;
            }
            else
            {
                g -= 1;
            }
            if (b < 255)
            {
                b += 1;
            }
            else
            {
                b -= 1;
            }
            background.color = new Color(r, g, b);
            Debug.Log(r + " " + g + " " + b);
            counter += 1;
        }
    }
}
