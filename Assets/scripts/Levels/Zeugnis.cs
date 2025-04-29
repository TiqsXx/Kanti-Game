using System;
using TMPro;
using Unity.VisualScripting;

//using UnityEditor.Build.Player;
using UnityEngine;

public class Zeugnis : MonoBehaviour
{
    string[] scores = { "ScoreMus1", "ScoreEng1", "ScoreDeu1", "ScoreGeo1", "ScoreFra1" };
    public TextMeshProUGUI[] specialfacher;
    public TextMeshProUGUI[] facher;
    public TextMeshProUGUI notendurchschnitt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showScoreBoard();
        calculateMiddleValue();
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
            if (note != 0)
            {
                facher[n].text = facher[n].text + ": " + Math.Round(note, 2).ToString();
            }
            else if (note == 0)
            {
                facher[n].text = facher[n].text + ": 1";
            }
        }
        specialfacher[0].text = specialfacher[0].text + ": " + ((PlayerPrefs.GetInt("ScoreMath1")) + 2);
        specialfacher[1].text = specialfacher[1].text + ": " + ((PlayerPrefs.GetInt("ScorePhy1")) + 2);
        specialfacher[2].text = specialfacher[2].text + ": " + ((PlayerPrefs.GetInt("ScoreGes1")) + 1);
    }

    public void calculateMiddleValue()
    {
        decimal sumnote = 0;
        for (int n = 0; n < scores.Length; n++)
        {
            decimal note = (PlayerPrefs.GetInt(scores[n])) / 2;
            if (note != 0)
            {
                sumnote = sumnote + note;
            }
            else if (note == 0)
            {
                sumnote = sumnote + 1;
            }

        }
        sumnote = sumnote + 6 + ((PlayerPrefs.GetInt("ScoreMath1")) + 2) + ((PlayerPrefs.GetInt("ScorePhy1")) + 2) + ((PlayerPrefs.GetInt("ScoreGes1")) + 1);
        Debug.Log(sumnote);
        decimal midvalue = Math.Round((sumnote / 9), 2);
        notendurchschnitt.text = notendurchschnitt.text + ": " + midvalue.ToString();
    }
}
