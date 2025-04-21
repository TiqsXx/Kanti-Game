using UnityEngine;
using TMPro;

public class MainTextController : MonoBehaviour
{
    public TMP_Text textFeld;        // Das Textfeld, das den Text anzeigt
    public string[] textVarianten;   // Array von möglichen Textvarianten

    public void ChangeText()
    {
        if (textFeld == null || textVarianten.Length == 0)
        {
            Debug.LogWarning("Kein Textfeld oder keine Textoptionen gesetzt!");
            return;
        }

        // Zufälligen Index wählen
        int index = Random.Range(0, textVarianten.Length);

        // Setze den Text auf die zufällige Variante
        textFeld.text = textVarianten[index];

        // Gib den angezeigten Text in der Konsole aus
        Debug.Log("Aktuell angezeigtes Wort: " + textVarianten[index]);
    }
}
