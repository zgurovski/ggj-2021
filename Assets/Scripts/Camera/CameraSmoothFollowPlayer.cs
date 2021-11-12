using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollowPlayer : MonoBehaviour
{

    public bool FocusAtStart = true;
    public float dampTime = 0.15f;
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        if (FocusAtStart)
        {
            Vector3 targetPos = target.position;
            targetPos.z = transform.position.z;
            transform.position = targetPos;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 point = Camera.main.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}