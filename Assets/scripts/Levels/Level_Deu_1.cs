using TMPro;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Level_Deu_1 : MonoBehaviour
{
    public string[] answers;
    public TextMeshProUGUI[] inputFields;
    public TMP_InputField[] inputFields1;
    public int scoredeu;
    public TextMeshProUGUI score_text;
    public Button button_check;
    public Button button_back;
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_back.gameObject.SetActive(false); //Deaktiviert den Knopf
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDeu1Answers()
    {
        if (answers.Length == inputFields.Length)
        {
            for (int i = 0; i < 12; i++)
            {
                //if (answers[i].ToString().ToUpper().Trim() == inputFields[i].text.ToString().ToUpper().Trim())
                if (answers[i].Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "").Equals(inputFields1[i].text.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", ""), System.StringComparison.OrdinalIgnoreCase))
                {
                    inputFields1[i].image.color = Color.green;
                    scoredeu += 1;
                    score_text.text = "Score: " + scoredeu;
                }
                else
                {
                    inputFields1[i].image.color = Color.red;
                    //for (int j = 0; j < answers[i].Length; j++)
                    //{
                        // Case-insensitive comparison
                        //if (char.ToLower(answers[i][j]) != char.ToLower(inputFields[i].text[j]))
                        //{
                            // Output the wrong character
                           // Debug.Log($"Wrong character at index {j}: '{answers[i][j]}' (from str1) vs '{inputFields[i].text[j]}' (from str2)");
                            //return;  // Stop after finding the first mismatch
                        //}
                        //else
                        //{
                          //  Debug.Log("Match");
                        //}
                    //}
                }
            }
            button_check.gameObject.SetActive(false);
            button_back.gameObject.SetActive(true);
        }
    }
}
