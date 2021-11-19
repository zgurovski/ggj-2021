using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelectScript : MonoBehaviour
{

    private void Update()
    {




        SelectScene();

        // TO BE ADDED TO MOVEMENT SCRIPT
        // using UnityEngine.SceneManagement;
        //  private GameObject nextScene;
        // nextScene = GameObject.FindWithTag("NextScene");
        // void OnTriggerEnter2D(Collider2D coll)
        //{
        //    if (coll.tag == "TriggerNextScene")
        //    {
        //      SceneManager.LoadScene("LevelSelect");
        //        
        //    }
        //}


    }
    void SelectScene()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {

            if (hit)
            {
                if (hit.collider.CompareTag("TheNeighbourhood"))
                {
                    Debug.Log("hit");
                    SceneManager.LoadScene("TheNeighbourhood");
                }

                // TODO -- FINISH ELSE IF FOR THE REST OF THE SCENES

            }
        }
    }
   
}
