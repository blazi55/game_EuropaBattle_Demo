using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float mapMaxX, mapMaxY, mapMinX, mapMinY;

    private void Awake()
    {
        mapMinX = spriteRenderer.transform.position.x - spriteRenderer.bounds.size.x / 2f;
        mapMaxX = spriteRenderer.transform.position.x + spriteRenderer.bounds.size.x / 2f;

        mapMinY = spriteRenderer.transform.position.y - spriteRenderer.bounds.size.y / 2f;
        mapMaxY = spriteRenderer.transform.position.y + spriteRenderer.bounds.size.y / 2f;
    }

    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = ClampCamera(cam.transform.position + difference);
            //cam.transform.position += difference;
        }
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
