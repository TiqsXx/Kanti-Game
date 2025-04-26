using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class Level_Eng_1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentquestion = 0;
    public int score = 0;
    public string[] sentences;
    public int[] correctanswers;
    public Button[] buttons;
    public TMP_Dropdown answerbox;
    public TextMeshProUGUI question_text;
    public TextMeshProUGUI sentence_text;
    public TextMeshProUGUI score_text;
    public Button button_check;
    public Button button_continue;
    public Button button_back;

    void Start()
    {
        question_text.text = "Select the correct tense!";
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_check.gameObject.SetActive(false);
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
        int index = answerbox.value;
        answerbox.interactable = false;
        if (index == correctanswers[currentquestion])
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
            PlayerPrefs.SetString("Eng1Completed", "true");
            PlayerPrefs.SetInt("ScoreEng1", score);
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

        sentence_text.text = sentences[currentquestion];
        answerbox.interactable = true;
        answerbox.image.color = Color.white;
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_check.gameObject.SetActive(false);
    }
}
