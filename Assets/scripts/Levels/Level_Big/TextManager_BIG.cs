using UnityEngine;
using TMPro;

public class TextManager_BIO : MonoBehaviour
{
    public TMP_Text textFeld;
    public string[] textVarianten;

    public void ChangeText()
    {
        if (textVarianten.Length == 0 || textFeld == null) return;

        int index = Random.Range(0, textVarianten.Length);
        textFeld.text = textVarianten[index];
    }
}
