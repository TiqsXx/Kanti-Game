using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class Level_Math : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentquestion = 0;
    public int score = 0;
    public string[] question;
    public string[] answer;
    public Button[] buttons;
    public TextMeshProUGUI question_text;
    public TextMeshProUGUI score_text;
    public Button button0;
    public TextMeshProUGUI button1_text;
    public Button button1;
    public TextMeshProUGUI button2_text;
    public Button button2;
    public TextMeshProUGUI button3_text;
    public Button button3;
    public TextMeshProUGUI button4_text;
    public Button button_continue;
    public Button button_back;

    void Start()
    {
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_back.gameObject.SetActive(false);
        question_text.text = question[currentquestion];
        button1_text.text = answer[currentquestion * 4 + 0];
        button2_text.text = answer[currentquestion * 4 + 1];
        button3_text.text = answer[currentquestion * 4 + 2];
        button4_text.text = answer[currentquestion * 4 + 3];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonClicked(int clickedButton)
    {
        switch (currentquestion)
        {
            case 0:
                if (clickedButton == 1)
                {
                    button1.image.color = Color.green; //Ändert den Knopf mit der richtigen Antwort auf grün
                    score += 1;
                    score_text.text = "Score: " + score.ToString();

                }
                else
                {
                    buttons[clickedButton].image.color = Color.red; //Ändert den falsch angeklickten Knopf auf rot
                    button1.image.color = Color.green; //Ändert den Knopf mit der richtigen Antwort auf grün
                }
                break;
            case 1:
                if (clickedButton == 0)
                {
                    button0.image.color = Color.green;
                    score += 1;
                    score_text.text = "Score: " + score.ToString();
                }
                else
                {
                    buttons[clickedButton].image.color = Color.red;
                    button0.image.color = Color.green;
                }
                break;
            case 2:
                if (clickedButton == 3)
                {
                    button3.image.color = Color.green;
                    score += 1;
                    score_text.text = "Score: " + score.ToString();
                }
                else
                {
                    buttons[clickedButton].image.color = Color.red;
                    button3.image.color = Color.green;
                }
                break;
            case 3:
                if (clickedButton == 0)
                {
                    button0.image.color = Color.green;
                    score += 1;
                    score_text.text = "Score: " + score.ToString();
                }
                else
                {
                    buttons[clickedButton].image.color = Color.red;
                    button0.image.color = Color.green;
                }
                break;

        }
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        button_continue.gameObject.SetActive(true); //Aktiviert den Knopf
    }

    public void UpdateQuestions()
    {
        currentquestion = currentquestion + 1;
        if (currentquestion >= 4)
        {
            foreach (var button in buttons)
            {
                button.interactable = false;
            }
            button_back.gameObject.SetActive(true);
            PlayerPrefs.SetString("Math1Completed", "true");
            Debug.Log("end");
            return;
        }
        foreach (var button in buttons)
        {
            button.image.color = Color.white;
            button.interactable = true;
        }

        question_text.text = question[currentquestion];
        button1_text.text = answer[currentquestion * 4 + 0]; //Beim ersten Mal kommt 8, beim dritten mal 12
        button2_text.text = answer[currentquestion * 4 + 1];
        button3_text.text = answer[currentquestion * 4 + 2];
        button4_text.text = answer[currentquestion * 4 + 3];
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
    }
}
