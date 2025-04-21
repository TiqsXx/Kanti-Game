using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer; // Der LineRenderer, der die Linie zeichnet

    // Wird beim Start aufgerufen
    void Start()
    {
        // Initialisierung des LineRenderers
        if (_renderer == null)
        {
            _renderer = GetComponent<LineRenderer>();
        }
    }

    // Wird jeden Frame aufgerufen
    void Update()
    {
        // Hier könnte zusätzliche Logik platziert werden, falls benötigt
    }

    // Fügt einen neuen Punkt zur Linie hinzu
    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos)) return; // Überprüft, ob der Punkt hinzugefügt werden kann

        // Erhöht die Anzahl der Punkte im LineRenderer und fügt den neuen Punkt hinzu
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    // Überprüft, ob ein neuer Punkt hinzugefügt werden kann
    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true; // Wenn keine Punkte vorhanden sind, kann immer hinzugefügt werden

        // Überprüft den Abstand zum letzten Punkt
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }
}