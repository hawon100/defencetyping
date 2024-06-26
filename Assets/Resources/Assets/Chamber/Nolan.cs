using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nolan : MonoBehaviour
{
    public Canvas canvas; // Assign in the editor or through code
    public GameObject prefab; // Prefab to instantiate
    public Transform worldPosition; // World position to instantiate at

    void Start()
    {
        // Convert world position to screen coordinates
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition.position);

        // Create a new GameObject from the prefab
        GameObject newObject = Instantiate(prefab, canvas.transform);

        // Get the RectTransform component of the newly created GameObject
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();

        // Convert screen coordinates to canvas local coordinates
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, null, out Vector2 localPoint);

        // Set the anchored position of the RectTransform to the local point
        rectTransform.anchoredPosition = localPoint;
    }
}
