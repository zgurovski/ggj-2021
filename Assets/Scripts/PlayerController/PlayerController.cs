using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        if(animator == null)
        {
            Debug.Log("Animator is not defined!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (vertical > 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (vertical < 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (horizontal > 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (horizontal < 0)
        {
            animator.SetInteger("Direction", 3);
        }
    }
}
