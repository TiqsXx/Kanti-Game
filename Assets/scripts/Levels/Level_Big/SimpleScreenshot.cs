using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScreenshotToAssets : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Pfad zum Ordner innerhalb der Assets
            string folderPath = Path.Combine(Application.dataPath, "Screenshots");

            // Ordner erstellen, falls er nicht existiert
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Debug.Log("📁 Screenshot-Ordner erstellt unter: " + folderPath);
            }

            // Pfad zur Datei (immer gleich, wird überschrieben)
            string filePath = Path.Combine(folderPath, "drawing.png");

            // Screenshot machen
            ScreenCapture.CaptureScreenshot(filePath);
            Debug.Log("📸 Screenshot gespeichert unter: " + filePath);

            // Asset-Datenbank aktualisieren, damit Unity das neue Bild sieht (nur im Editor)
            #if UNITY_EDITOR
            EditorApplication.delayCall += () => AssetDatabase.Refresh();
            #endif
        }
    }
}
