using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
 


    private Animator animator;
    private GameObject nextScene;

    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        nextScene = GameObject.FindWithTag("NextScene");
       
        animator = this.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.Log("Animator is not defined!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Moving();

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

    void Moving()
    {
        transform.Translate(Vector2.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "TriggerNextScene")
        {

            SceneManager.LoadScene("LevelSelect");
        }
    }



}
