using PlayTextSupport;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheNeighbourhoodController : MonoBehaviour
{
    private StoryState storyState;

    // Start is called before the first frame update
    public void Start()
    {
        EventCenter.GetInstance().AddEventListener("TheElderFirstTalk", onFirstTalkEnd);
        storyState = GameObject.FindObjectOfType<StoryState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFirstTalkEnd()
    {
        Debug.Log(2);
        storyState.currentState++;
    }
}
