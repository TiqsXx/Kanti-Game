using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;
using UnityEngine.InputSystem;

public class Level_Geo_1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentquestion = 0;
    public int score = 0;
    public string[] question;
    public Vector3[] correctLocation;
    public Button[] buttons;
    public Image locationmarker;
    public Image locationmarker_correct;
    public TextMeshProUGUI question_text;
    public TextMeshProUGUI score_text;
    public Button button_continue;
    public Button button_back;

    void Start()
    {
        //distanceline.sortingOrder = 1;
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_back.gameObject.SetActive(false);
        locationmarker_correct.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        setMarker();
    }
    void setMarker()
    {
        if (Input.GetMouseButtonDown(0)) //Wurde die Maus auch gedrückt?
        {
            if (Input.mousePosition.x > 1187 && Input.mousePosition.y > 315 && Input.mousePosition.x < 1726.5 && Input.mousePosition.y < 731) //Wurde die Maus auch innerhalb der Karte geklickt
            { //Wenn ja, dann setze den Kreis auf diese Position

                //Aus dem Forum https://discussions.unity.com/t/get-coordinates-of-mouse-click-on-plane/192333
                locationmarker.rectTransform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                button_continue.gameObject.SetActive(true);
                Debug.Log(locationmarker.rectTransform.position);
            }
            //Wenn nein, dann lasse den Kreis dort wo er ist.
        }
    }
    public void CheckLocation()
    {
        Vector3 circlePosition = locationmarker.rectTransform.position;
        if ( circlePosition.x - correctLocation[currentquestion].x < 50 && circlePosition.y - correctLocation[currentquestion].y < 50)
        {
            score += 1;
            score_text.text = "Score: " + score;
        }
        else
        {
            locationmarker_correct.gameObject.SetActive(true);
            locationmarker_correct.rectTransform.position = correctLocation[currentquestion];
        }
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
            Debug.Log("end");
            return;
        }
        foreach (var button in buttons)
        {
            button.image.color = Color.white;
            button.interactable = true;
        }

        question_text.text = question[currentquestion];
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
    }
}