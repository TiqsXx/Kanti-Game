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
    public Sprite[] locationimages;
    public Vector3[] correctLocation;
    public Button[] buttons;
    public Image location;
    public Image locationmarker;
    public Image locationmarker_green;
    public TextMeshProUGUI question_text;
    public TextMeshProUGUI score_text;
    public Button button_continue;
    public Button button_back;
    int clickedtimes = 1;

    void Start()
    {
        //distanceline.sortingOrder = 1;
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
        button_back.gameObject.SetActive(false);
        locationmarker_green.gameObject.SetActive(false);
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
            if (Input.mousePosition.x > 1187 && Input.mousePosition.y > 315 && Input.mousePosition.x < 1726.5 && Input.mousePosition.y < 741) //Wurde die Maus auch innerhalb der Karte geklickt
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
        if (clickedtimes % 2 != 0) //Habe ich eine ungerade Anzahl auf dem Knopf gedrückt, so wird es nur gecheckt
        {
            Vector3 circlePosition = locationmarker.rectTransform.position;
            if (Math.Abs(circlePosition.x - correctLocation[currentquestion].x) < 50 && Math.Abs(circlePosition.y - correctLocation[currentquestion].y) < 50)
            {
                score += 1;
                score_text.text = "Score: " + score;
            }
            else
            {
                locationmarker_green.gameObject.SetActive(true);
                locationmarker_green.rectTransform.position = correctLocation[currentquestion];
            }
            clickedtimes += 1;
        }
        else if (clickedtimes % 2 == 0) //Habe ich eine gerade Anzahl (z. B. zweimal) geklickt so geht es weiter.
        {
            clickedtimes += 1;
            UpdateQuestions();
        }
    }

    public void UpdateQuestions()
    {
        button_continue.gameObject.SetActive(false);
        currentquestion = currentquestion + 1;
        if (currentquestion >= 18)
        {
            button_back.gameObject.SetActive(true);
            PlayerPrefs.SetString("Geo1Completed", "true");
            score = score > 12 ? 12 : score;
            PlayerPrefs.SetInt("ScoreGeo1", score);
            Debug.Log("end");
            return;
        }
        location.sprite = locationimages[currentquestion];
        locationmarker_green.gameObject.SetActive(false);
        button_continue.gameObject.SetActive(false); //Deaktiviert den Knopf
    }
}