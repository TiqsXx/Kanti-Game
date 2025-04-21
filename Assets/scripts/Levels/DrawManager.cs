using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Für Button-Verwendung

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;

    public const float RESOLUTION = 0.1f;

    private Line _currentLine;

    // Plane, auf der gezeichnet wird
    [SerializeField] private LayerMask drawLayer; // Der Layer, der für das Zeichnen genutzt wird

    // Liste, um alle erstellten Linien zu speichern
    private List<Line> drawnLines = new List<Line>();

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        // Mausposition in Weltkoordinaten umwandeln
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, drawLayer))
        {
            Vector3 hitPosition = hit.point; // Die Position auf der Fläche, die der Ray trifft

            if (Input.GetMouseButtonDown(0))
            {
                _currentLine = Instantiate(_linePrefab, hitPosition, Quaternion.identity);
                drawnLines.Add(_currentLine); // Die Linie zur Liste hinzufügen
            }

            if (Input.GetMouseButton(0))
            {
                _currentLine.SetPosition(hitPosition);
            }
        }
    }

    // Methode zum Löschen aller gezeichneten Linien
    public void ClearDrawings()
    {
        foreach (Line line in drawnLines)
        {
            Destroy(line.gameObject); // Lösche jedes Line-Objekt
        }

        drawnLines.Clear(); // Leere die Liste
    }
}
