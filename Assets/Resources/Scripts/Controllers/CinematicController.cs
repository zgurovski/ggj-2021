using PlayTextSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicController : MonoBehaviour
{
    public GameObject talkingManager;
    private SceneLoader sceneLoader;
    private StoryState storyState;
    // Start is called before the first frame update
    void Start()
    {
     //   talkingManager = GameObject.
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        EventCenter.GetInstance().AddEventListener("CinematicEnd", OnIntroEnd);
        storyState = GameObject.FindObjectOfType<StoryState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnIntroEnd()
    {
        Debug.Log("end");
        talkingManager.SetActive(false);
        sceneLoader.LoadScene("TheNeighbourhood");
        storyState.currentState++;
    }
}
