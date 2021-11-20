using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnimator : MonoBehaviour
{
    public float factor = 0.03f;
    public float speed = 4f;
    private float y;

    void Start()
    {
        this.y = this.transform.localPosition.y;
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, y + this.GetComponentInParent<Rigidbody2D>().position.y + Mathf.Cos(Time.time * speed) * factor, transform.position.z);
    }
}
