using PlayTextSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheNeighbourhoodController : MonoBehaviour
{
    private StoryState storyState;

    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener("TheElder.FirstTalk", onFirstTalkEnd);
        storyState = GameObject.FindObjectOfType<StoryState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onFirstTalkEnd()
    {
        storyState.currentState++;
    }
}
