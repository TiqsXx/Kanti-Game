using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AI_PredictionController : MonoBehaviour
{
    // Dein API-Key
    private string apiToken = "Bearer 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"; // Dein API-Schlüssel
    private string apiUrl = "https://api-inference.huggingface.co/models/ashudeep/quickdraw-classifier-tfjs";  // Beispiel-URL für QuickDraw-Modell

    // Funktion, um Screenshot vom Zeichenpad zu machen und API-Aufruf zu senden
    public void CaptureDrawingAndPredict(RenderTexture renderTexture)
    {
        StartCoroutine(SaveAndPredict(renderTexture));
    }

    // Methode zum Speichern und Anfragen der API
    IEnumerator SaveAndPredict(RenderTexture renderTexture)
    {
        // RenderTexture in ein Bild konvertieren
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // Bild in PNG umwandeln
        byte[] imageBytes = texture.EncodeToPNG();
        Destroy(texture); // Speicher freigeben

        // API-Anfrage vorbereiten
        UnityWebRequest www = new UnityWebRequest(apiUrl, "POST");
        www.uploadHandler = new UploadHandlerRaw(imageBytes);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Authorization", apiToken);
        www.SetRequestHeader("Content-Type", "application/octet-stream");

        // API-Anfrage senden und warten
        yield return www.SendWebRequest();

        // Antwort auswerten
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Fehler: " + www.error);
        }
        else
        {
            string result = www.downloadHandler.text;
            Debug.Log("AI sagt: " + result);
            // Hier kannst du das Ergebnis weiter verarbeiten (z. B. Punktesystem)
        }
    }
}
