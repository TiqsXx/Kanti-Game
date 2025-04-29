using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Threading;
using System;

public class Level_Ges_1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentquestion = 0;
    public int score = 0;
    public string[] question;
    public int[] correctanswers;
    public string[] answer;
    public Button[] buttons;
    public TextMeshProUGUI question_text;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI button0_text;
    public TextMeshProUGUI button1_text;
    public TextMeshProUGUI button2_text;
    public TextMeshProUGUI button3_text;
    public Button button_continue;
    public Button button_back;
    public AudioSource change;

    void Start()
    {
        change.volume = 0f;
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_back.gameObject.SetActive(false);
        question_text.text = question[currentquestion];
        button0_text.text = answer[currentquestion * 4 + 0];
        button1_text.text = answer[currentquestion * 4 + 1];
        button2_text.text = answer[currentquestion * 4 + 2];
        button3_text.text = answer[currentquestion * 4 + 3];
    }

    // Update is called once per frame
    void Update()
    {
        fadeIn();
    }
    public void ButtonClicked(int clickedButton)
    {
        if (clickedButton == correctanswers[currentquestion])
        {
            buttons[clickedButton].image.color = Color.green; //Ändert den Knopf mit der richtigen Antwort auf grün
            score += 1;
            score_text.text = "Score: " + score.ToString();
        }
        else
        {
            buttons[clickedButton].image.color = Color.red; //Ändert den falsch angeklickten Knopf auf rot
            buttons[correctanswers[currentquestion]].image.color = Color.green; //Ändert den Knopf mit der richtigen Antwort auf grün
        }
        
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        button_continue.gameObject.SetActive(true); //Aktiviert den Knopf
    }

    public void UpdateQuestions()
    {
        currentquestion += 1;
        if (currentquestion >= 5)
        {
            foreach (var button in buttons)
            {
                button.interactable = false;
            }
            button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
            button_back.gameObject.SetActive(true);
            PlayerPrefs.SetString("Ges1Completed", "true");
            PlayerPrefs.SetInt("ScoreGes1", score);
            Debug.Log("end");
            return;
        }
        foreach (var button in buttons)
        {
            button.image.color = Color.white;
            button.interactable = true;
        }

        question_text.text = question[currentquestion];
        button0_text.text = answer[currentquestion * 4 + 0]; //Beim ersten Mal kommt 8, beim dritten mal 12
        button1_text.text = answer[currentquestion * 4 + 1];
        button2_text.text = answer[currentquestion * 4 + 2];
        button3_text.text = answer[currentquestion * 4 + 3];
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
    }
    void fadeIn()
    {
        if (change.volume >= 1f)
        {
            return;
        }
        else
        {
            float newVolume = change.volume + (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume > 1f)
            {
                newVolume = 1f;
            }
            change.volume = newVolume;
        }
    }
}
