using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckNAWIBuilding : MonoBehaviour
{
    string[] mainkeys = { "Inf1Completed", "Phy1Completed" };
    public Button[] levels;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < mainkeys.Length; i++)
        {
            if (PlayerPrefs.GetString(mainkeys[i]) == "true")
            {
                levels[i].interactable = false;
                levels[i].image.color = Color.green;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
