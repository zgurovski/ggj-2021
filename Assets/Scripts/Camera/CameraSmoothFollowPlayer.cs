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
    //TODO: change type to Vector2
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
    void Update()
    {
        if (target == null) return;

        Vector3 point = Camera.main.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        Vector3 result = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        if (CameraIsAtTheEdge()) {
            return;
        }

        transform.position = result;
    }

    private bool CameraIsAtTheEdge()
    {
        Debug.Log(transform.position.y + " => " + cameraBounds.size.y + " => " + backgroundBounds.y);
        
        // We have reached the top edge of the background and we stop
        if (transform.position.y + (cameraBounds.size.y / 2) > backgroundBounds.y - offsetX)
        {
            return true;
        }
        return false;
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