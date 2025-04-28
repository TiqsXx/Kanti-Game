using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowReportCard : MonoBehaviour
{
    string[] facher = { "Phy1Completed", "Math1Completed", "Mus1Completed", "Eng1Completed", "Deu1Completed", "Inf1Completed", "Geo1Completed" };
    int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (string fach in facher)
        {
            if (PlayerPrefs.GetString(fach) == "true")
            {
                counter += 1;
            }
        }
        
        if (counter == facher.Length)
        {
            SceneManager.LoadSceneAsync(21);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
