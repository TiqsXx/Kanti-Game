using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;

    public const float RESOLUTION = 0.1f;

    private Line _currentLine;

    // Plane, auf der gezeichnet wird
    [SerializeField] private LayerMask drawLayer; // Der Layer, der für das Zeichnen genutzt wird

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
            }

            if (Input.GetMouseButton(0))
            {
                _currentLine.SetPosition(hitPosition);
            }
        }
    }
}
