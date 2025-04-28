using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class Level_Fra_1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentquestion = 0;
    public int score = 0;
    public string[] questions;
    public string[] sentences;
    public string[] correctanswers;
    public TMP_InputField answerbox;
    public TextMeshProUGUI question_text;
    public TextMeshProUGUI sentence_text;
    public TextMeshProUGUI score_text;
    public Button button_check;
    public Button button_continue;
    public Button button_back;

    void Start()
    {
        question_text.text = questions[currentquestion];
        button_continue.gameObject.SetActive(false);
        button_back.gameObject.SetActive(false);
        sentence_text.text = sentences[currentquestion];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemChanged()
    {
        button_check.gameObject.SetActive(true); //Aktiviert den Knopf
    }
    public void CheckAnswer()
    {
        string answer = answerbox.text;
        answerbox.interactable = false;
        Debug.Log(answer.ToString().ToUpper().Trim() + " | " + correctanswers[currentquestion].ToString().ToUpper().Trim());
        if (answer.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "").Equals(correctanswers[currentquestion].Trim().Replace("\n", "").Replace("\r", "").Replace("\t", ""), System.StringComparison.OrdinalIgnoreCase))
        {
            answerbox.image.color = Color.green;
            score += 1;
            score_text.text = "Score: " + score.ToString();
        }
        else
        {
            answerbox.image.color = Color.red;
        }
        button_continue.gameObject.SetActive(true);
        if (currentquestion >= 11)
        {
            button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
            button_check.gameObject.SetActive(false);
            button_back.gameObject.SetActive(true);
            PlayerPrefs.SetString("Fra1Completed", "true");
            PlayerPrefs.SetInt("ScoreFra1", score);
            Debug.Log("end");
            return;
        }
    }

    public void UpdateQuestions()
    {
        currentquestion += 1;
        if (currentquestion >= 12)
        {
            button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
            button_check.gameObject.SetActive(false);
            button_back.gameObject.SetActive(true);
            Debug.Log("end");
            return;
        }
        answerbox.image.color = Color.white;
        answerbox.text = "";
        answerbox.interactable = true;
        sentence_text.text = sentences[currentquestion];
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
    }
}
