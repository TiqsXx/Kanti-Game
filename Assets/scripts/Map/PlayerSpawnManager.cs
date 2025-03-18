using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform defaultSpawnPoint; // Standard-Spawnpunkt (im Inspector zuweisen)

    void Start()
    {
        // Prüfen, ob der Spieler aus einer anderen Szene zurückkommt
        if (PlayerPrefs.GetString("LastScene") == SceneManager.GetActiveScene().name)
        {
            if (PlayerPrefs.HasKey("ReturnX"))
            {
                float x = PlayerPrefs.GetFloat("ReturnX");
                float y = PlayerPrefs.GetFloat("ReturnY");
                float z = PlayerPrefs.GetFloat("ReturnZ");

                transform.position = new Vector3(x, y, z); // Setze gespeicherte Position
                return;
            }
        }

        // Falls kein gespeicherter Spawnpunkt existiert, nutze den Standard-Spawnpunkt
        if (defaultSpawnPoint != null)
        {
            transform.position = defaultSpawnPoint.position;
        }
        else
        {
            Debug.LogWarning("Kein Standard-Spawnpunkt gesetzt! Stelle sicher, dass dein Spieler an einer sicheren Position spawnt.");
        }
    }
}
