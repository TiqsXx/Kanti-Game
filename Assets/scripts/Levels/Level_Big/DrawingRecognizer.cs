using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class HFLabel
{
    public string label;  // Nur das Label ohne den Score
}

public class DrawingRecognizer : MonoBehaviour
{
    // TMP_Text für das gesuchte Wort, das du im Inspector zuweisen kannst
    public TMP_Text gesuchtesWortText; 

    // TMP_Text für die Antwort von der API (wird im Spiel angezeigt)
    public TMP_Text apiAntwortText;

    // TMP_Text für den Score (Anzeige im Spiel)
    public TMP_Text scoreText;

    // Initialer Score
    private int score = 0;

    string apiKey = "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";
    string modelUrl = "https://api-inference.huggingface.co/models/google/vit-base-patch16-224";
    string imageFileName = "drawing.png";
    string screenshotPath;

    void Start()
    {
        // Prüfe, ob das TMP_Text-Feld für das gesuchte Wort, API-Antwort und Score korrekt zugewiesen wurden
        if (gesuchtesWortText == null || apiAntwortText == null || scoreText == null)
        {
            Debug.LogError("❌ TMP_Text-Felder für gesuchtes Wort, API-Antwort und/oder Score wurden nicht zugewiesen!");
            return;
        }

        // Initialisiere den Score Text
        scoreText.text = "Score: 0";

        // Pfad zum Screenshot setzen
        screenshotPath = Path.Combine(Application.dataPath, "Screenshots", imageFileName);
    }

    void Update()
    {
        // Prüfe, ob die F-Taste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F-Taste gedrückt!");  // Bestätigung, dass die Taste erkannt wird
            StartCoroutine(ProcessDrawingAndSend());
        }
    }

    // Lese das gesuchte Wort aus dem TMP_Text-Feld
    string GetGesuchtesWortFromTMP()
    {
        if (gesuchtesWortText != null)
        {
            return gesuchtesWortText.text.Trim(); // Text aus TMP_Text lesen
        }
        else
        {
            Debug.LogError("❌ Das TMP_Text-Feld für das gesuchte Wort ist nicht zugewiesen!");
            return "";
        }
    }

    IEnumerator ProcessDrawingAndSend()
    {
        // Lese das gesuchte Wort aus dem TMP_Text-Feld
        string gesuchtesWort = GetGesuchtesWortFromTMP();
        if (string.IsNullOrEmpty(gesuchtesWort))
        {
            Debug.LogWarning("⚠️ Kein gesuchtes Wort gefunden. Abbruch.");
            yield break;
        }

        // Überprüfe, ob das Screenshot existiert
        if (!File.Exists(screenshotPath))
        {
            Debug.LogError("⚠️ Screenshot nicht gefunden unter: " + screenshotPath);
            yield break;
        }

        Debug.Log("📤 Lade Bild: " + screenshotPath);
        byte[] imageBytes = File.ReadAllBytes(screenshotPath);

        // Sende das Bild an Hugging Face API
        UnityWebRequest request = UnityWebRequest.Put(modelUrl, imageBytes);
        request.method = UnityWebRequest.kHttpVerbPOST;
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);
        request.SetRequestHeader("Content-Type", "application/octet-stream");

        Debug.Log("🔁 Sende Bild an Hugging Face...");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Fehler: " + request.error);
            yield break;
        }

        // Verarbeite die Antwort von Hugging Face
        string responseText = request.downloadHandler.text;
        Debug.Log("📩 Antwort: " + responseText);

        // Setze die Antwort der API im TMP_Text-Feld (wird im Spiel angezeigt)
        if (apiAntwortText != null)
        {
            apiAntwortText.text = "API Antwort: " + responseText; // Hier kannst du die Antwort formatieren, wie du möchtest
        }

        // Label extrahieren
        HFLabel[] labels = JsonHelper.FromJsonArray<HFLabel>(responseText);
        if (labels.Length > 0)
        {
            string allLabels = "";  // String für alle Labels

            // Füge alle Labels zusammen
            foreach (HFLabel label in labels)
            {
                allLabels += label.label + "\n";  // Label in eine neue Zeile hinzufügen
            }

            Debug.Log("✅ Erkannte Objekte: \n" + allLabels);

            // Zeige die erkannten Labels im TMP_Text-Feld an
            if (apiAntwortText != null)
            {
                apiAntwortText.text = "Erkannte Objekte: \n" + allLabels; // Alle Labels anzeigen
            }

            // Vergleiche das erkannte Label mit dem gesuchten Wort
            foreach (HFLabel label in labels)
            {
                if (label.label.ToLower() == gesuchtesWort.ToLower())
                {
                    // Wenn eine Übereinstimmung gefunden wurde, erhöhe den Score
                    score++;
                    Debug.Log("🎉 Score erhöht! Neuer Score: " + score);
                    scoreText.text = "Score: " + score;  // Setze den neuen Score im TMP_Text-Feld
                    break;  // Es wird nur 1 Punkt pro erfolgreicher Übereinstimmung vergeben
                }
            }
        }
        else
        {
            Debug.LogWarning("🤷 Keine Labels erhalten.");
        }
    }
}
