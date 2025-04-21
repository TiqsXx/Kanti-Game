using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class Level_Mus_1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentquestion = 0;
    public int score = 0;
    public string[] question;
    public Sprite[] question_images;
    public float[] question_image_multiplier;
    public int[] correctanswers;
    public Image imageObject;
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

    void Start()
    {
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_back.gameObject.SetActive(false);
        question_text.text = question[currentquestion];
        imageObject.sprite = question_images[currentquestion];
        imageObject.type = Image.Type.Tiled; //Setzt den Bildtyp auf Tiled, der einen Zoom und Abschneiden erlaubt
        imageObject.pixelsPerUnitMultiplier = question_image_multiplier[currentquestion]; //Setzt den Multiplier, damit das Bild vollständig zu sehen ist
        button0_text.text = answer[currentquestion * 4 + 0];
        button1_text.text = answer[currentquestion * 4 + 1];
        button2_text.text = answer[currentquestion * 4 + 2];
        button3_text.text = answer[currentquestion * 4 + 3];
    }

    // Update is called once per frame
    void Update()
    {

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
        if (currentquestion >= 12)
        {
            foreach (var button in buttons)
            {
                button.interactable = false;
            }
            button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
            button_back.gameObject.SetActive(true);
            Debug.Log("end");
            return;
        }
        foreach (var button in buttons)
        {
            button.image.color = Color.white;
            button.interactable = true;
        }

        question_text.text = question[currentquestion];
        imageObject.sprite = question_images[currentquestion];
        imageObject.type = Image.Type.Tiled; //Setzt den Bildtyp auf Tiled, der einen Zoom und Abschneiden erlaubt
        imageObject.pixelsPerUnitMultiplier = question_image_multiplier[currentquestion]; //Setzt den Multiplier, damit das Bild vollständig zu sehen ist
        button0_text.text = answer[currentquestion * 4 + 0]; //Beim ersten Mal kommt 8, beim dritten mal 12
        button1_text.text = answer[currentquestion * 4 + 1];
        button2_text.text = answer[currentquestion * 4 + 2];
        button3_text.text = answer[currentquestion * 4 + 3];
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
    }
}
