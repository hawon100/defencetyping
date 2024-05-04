using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    public float zoomStep = 4, minCamSize = 0.1f, maxCamSize = 5f;

    public Image map;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private Vector3 dragOrigin;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        Vector3[] corners = new Vector3[4];
        map.rectTransform.GetWorldCorners(corners);

        mapMinX = corners[0].x;
        mapMaxX = corners[2].x;
        mapMinY = corners[0].y;
        mapMaxY = corners[1].y;
    }

    private void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
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
