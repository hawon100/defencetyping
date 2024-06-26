using System;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    public Camera cam;
    public float zoomStep = 1f, minCamSize = 5f, maxCamSize = 20f;

    public GameObject background;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private Vector3 dragOrigin;

    private void Awake()
    {
        InitializeBackgroundBounds();
    }

    private void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    private void InitializeBackgroundBounds()
    {
        SpriteRenderer backgroundRenderer = background.GetComponent<SpriteRenderer>();

        if (backgroundRenderer != null)
        {
            mapMinX = background.transform.position.x - backgroundRenderer.bounds.size.x / 2f;
            mapMaxX = background.transform.position.x + backgroundRenderer.bounds.size.x / 2f;
            mapMinY = background.transform.position.y - backgroundRenderer.bounds.size.y / 2f;
            mapMaxY = background.transform.position.y + backgroundRenderer.bounds.size.y / 2f;
        }
        else
        {
            Debug.LogError("Background GameObject does not have a SpriteRenderer component.");
        }
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
    }

    private void ZoomCamera()
    {
        float newSize = cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
