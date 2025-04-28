using TMPro;
//using UnityEditor.Build.Player;
using UnityEngine;

public class Zeugnis : MonoBehaviour
{
    string[] scores = { "ScoreMus1", "ScoreEng1", "ScoreDeu1", "ScoreGeo1" };
    public TextMeshProUGUI[] specialfacher;
    public TextMeshProUGUI[] facher; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showScoreBoard()
    {
        for (int n = 0; n < scores.Length; n++)
        {
            decimal note = (PlayerPrefs.GetInt(scores[n])) / 2;
            facher[n].text = facher[n].text + ": " + note;
        }
        specialfacher[0].text = specialfacher[0].text + ": " + ((PlayerPrefs.GetInt("ScoreMath1")) + 2);
        specialfacher[1].text = specialfacher[1].text + ": " + ((PlayerPrefs.GetInt("ScoreMath1")) + 2);
    }
}
