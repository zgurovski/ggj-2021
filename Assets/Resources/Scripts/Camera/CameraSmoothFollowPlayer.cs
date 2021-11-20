using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollowPlayer : MonoBehaviour
{

    public bool FocusAtStart = true;
    public float dampTime = 0.15f;
    public Transform target;
    public Transform background;
    
    private Vector3 velocity = Vector3.zero;
    private Vector2 backgroundBounds;
    private Bounds cameraBounds;
    private float offsetX = 0.5f;
    private float offsetY = 0.5f;

    private void Start()
    {
        if (FocusAtStart)
        {
            Vector3 targetPos = target.position;
            targetPos.z = transform.position.z;
            transform.position = targetPos;
        }

        // Get tge background bounds
        backgroundBounds = new Vector2(
            background.GetComponent<SpriteRenderer>().bounds.size.x / 2,
            background.GetComponent<SpriteRenderer>().bounds.size.y / 2);

        // Get the camera bounds
        cameraBounds = OrthographicBounds(Camera.main);
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        float clampXPositive = (float)System.Math.Round(backgroundBounds.x - offsetX - (cameraBounds.size.x / 2f), 2);
        float clampXNegative = (float)System.Math.Round(-backgroundBounds.x + offsetX + (cameraBounds.size.x / 2f));
        float clampYPositive = (float)System.Math.Round(backgroundBounds.y - offsetY - (cameraBounds.size.y / 2f));
        float clampYNegative = (float)System.Math.Round(-backgroundBounds.y + offsetY + (cameraBounds.size.y / 2f));

        Vector3 destination = new Vector3(
            Mathf.Clamp(target.position.x, clampXNegative, clampXPositive),
            Mathf.Clamp(target.position.y, clampYNegative, clampYPositive),
            transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }

    /**
     * Get the ortigraphic bounds of the camera
     */
    private Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}