//Gesamter Code wurde mithilfe eines Tutorials erstellt
using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Füge diese Zeile hinzu, um Szenenwechsel zu ermöglichen

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string text;
        public bool hasChoices;
        public string[] choices;
        public int[] nextIndexes;
    }

    public TextMeshProUGUI textComponent;
    public GameObject choicePanel;

    // Maximal 4 Buttons (die du vorher in Unity setzt)
    public Button[] choiceButtons;

    public float textSpeed = 0.05f;

    private int index;

    // Neues Feld für den Szenenindex
    public int sceneIndexToLoad = -1; // Standardwert -1 bedeutet kein Szenenwechsel

    // Beispiel-Dialoge
    public DialogueLine[] lines = new DialogueLine[]
    {
        new DialogueLine 
        { 
            text = "Hallo, wie geht es dir?", 
            hasChoices = true, 
            choices = new string[] { "Gut!", "Schlecht..." }, 
            nextIndexes = new int[] { 1, 2 } 
        },
        new DialogueLine 
        { 
            text = "Schön zu hören!", 
            hasChoices = false, 
            choices = new string[] {}, 
            nextIndexes = new int[] {} 
        },
        new DialogueLine 
        { 
            text = "Oh, das tut mir leid.", 
            hasChoices = false, 
            choices = new string[] {}, 
            nextIndexes = new int[] {} 
        }
    };

    void Start()
    {
        textComponent.text = string.Empty;
        choicePanel.SetActive(false);
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !lines[index].hasChoices)
        {
            if (textComponent.text == lines[index].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index].text;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = "";
        foreach (char c in lines[index].text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        if (lines[index].hasChoices)
        {
            ShowChoices();
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Dialog ist beendet, überprüfe ob ein Szenenwechsel durchgeführt werden soll
            if (sceneIndexToLoad >= 0)
            {
                SceneManager.LoadScene(sceneIndexToLoad);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void ShowChoices()
    {
        choicePanel.SetActive(true);

        // Alle Buttons zuerst deaktivieren
        foreach (Button btn in choiceButtons)
        {
            btn.gameObject.SetActive(false);
        }

        // Nur so viele Buttons aktivieren, wie nötig
        for (int i = 0; i < lines[index].choices.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(true);
            TextMeshProUGUI buttonText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = lines[index].choices[i];

            int choiceIndex = i; // WICHTIG: Lokale Kopie für den Listener
            choiceButtons[i].onClick.RemoveAllListeners();
            choiceButtons[i].onClick.AddListener(() => ChooseOption(choiceIndex));
        }
    }

    public void ChooseOption(int choiceIndex)
    {
        choicePanel.SetActive(false);
        index = lines[index].nextIndexes[choiceIndex];
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
}