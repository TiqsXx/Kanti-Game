using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

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
    //Berechnet die Skalierung zwischen Editorfenster und Bildschirm, damit das Mausklicken die richtige Position erzeugt, dieses Problem entsteht aufgrund von verschiedenen Bildschirmauflösungen
    float scalefactorX = Screen.width / 1920f;
    float scalefactorY = Screen.height / 1080f;

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
            Debug.Log(Input.mousePosition.x + " | " + Input.mousePosition.y);
            if (Input.mousePosition.x > (1187 * scalefactorX) && Input.mousePosition.y > (315 * scalefactorY) && Input.mousePosition.x < (1726.5 * scalefactorX) && Input.mousePosition.y < (741 * scalefactorY)) //Wurde die Maus auch innerhalb der Karte geklickt
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
            if (Math.Abs(circlePosition.x - correctLocation[currentquestion].x * scalefactorX) < (50 * scalefactorX) && Math.Abs(circlePosition.y - correctLocation[currentquestion].y * scalefactorY) < (50 * scalefactorY))
            {
                score += 1;
                score_text.text = "Score: " + score;
            }
            else
            {
                locationmarker_green.gameObject.SetActive(true);
                locationmarker_green.rectTransform.position = new Vector3(correctLocation[currentquestion].x * scalefactorX, correctLocation[currentquestion].y * scalefactorY, correctLocation[currentquestion].z);
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