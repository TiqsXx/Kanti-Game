using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class HFLabel
{
    public string label;
}

public class DrawingRecognizer : MonoBehaviour
{
    public TMP_Text gesuchtesWortText;
    public TMP_Text apiAntwortText;
    public TMP_Text scoreText;

    private int score = 0;

    // ✔️ NEUER API-KEY
    string apiKey = "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";

    // ✔️ Hugging Face Modell (Image Classification)
    string modelUrl = "https://api-inference.huggingface.co/models/google/vit-base-patch16-224";

    string imageFileName = "drawing.png";
    string screenshotPath;

    void Start()
    {
        if (gesuchtesWortText == null || apiAntwortText == null || scoreText == null)
        {
            Debug.LogError("❌ TMP_Text-Felder nicht zugewiesen!");
            return;
        }

        scoreText.text = "Score: 0";
        screenshotPath = Path.Combine(Application.dataPath, "Screenshots", imageFileName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ProcessDrawingAndSend());
        }
    }

    string GetGesuchtesWortFromTMP()
    {
        return gesuchtesWortText != null ? gesuchtesWortText.text.Trim() : "";
    }

    IEnumerator ProcessDrawingAndSend()
    {
        string gesuchtesWort = GetGesuchtesWortFromTMP();
        if (string.IsNullOrEmpty(gesuchtesWort))
        {
            Debug.LogWarning("⚠️ Kein gesuchtes Wort.");
            yield break;
        }

        if (!File.Exists(screenshotPath))
        {
            Debug.LogError("⚠️ Screenshot nicht gefunden unter: " + screenshotPath);
            yield break;
        }

        byte[] imageBytes = File.ReadAllBytes(screenshotPath);

        UnityWebRequest request = new UnityWebRequest(modelUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(imageBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);
        request.SetRequestHeader("Content-Type", "application/octet-stream");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Fehler: " + request.error);
            Debug.LogError("Antwort: " + request.downloadHandler.text);
            yield break;
        }

        string responseText = request.downloadHandler.text;
        Debug.Log("📩 Antwort: " + responseText);
        if (apiAntwortText != null)
        {
            apiAntwortText.text = "API Antwort: " + responseText;
        }

        HFLabel[] labels = JsonHelper.FromJsonArray<HFLabel>(responseText);
        if (labels.Length > 0)
        {
            string allLabels = "";
            foreach (HFLabel label in labels)
            {
                allLabels += label.label + "\n";
            }

            apiAntwortText.text = "Erkannte Objekte:\n" + allLabels;

            foreach (HFLabel label in labels)
            {
                if (label.label.ToLower() == gesuchtesWort.ToLower())
                {
                    score++;
                    scoreText.text = "Score: " + score;
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning("🤷 Keine Labels erhalten.");
        }
    }
}

