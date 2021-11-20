using GraphSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StoryState;

public class InteractableGraph : MonoBehaviour
{
    public DialogueGraph Graph;
    public CONDITION condition;
    public STORYSTATE state;
    public float range = 2f;
    public bool active;
    private GameObject storyManager;
    private GameObject talkChecker;
    private QuestionAnimator question;

    public DialogueGraph GetGraph()
    {
        return active ? Graph : null;
    }

    // Start is called before the first frame update
    void Start()
    {
        storyManager = GameObject.Find("StoryManager");
        this.talkChecker = GameObject.FindGameObjectWithTag("TalkChecker");

        question = gameObject.GetComponentInChildren<QuestionAnimator>();
        hideQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        STORYSTATE currentState = storyManager.GetComponent<StoryState>().currentState;

        if (condition == CONDITION.BEFORE)
        {
            active = currentState < state;
        }
        else if (condition == CONDITION.EXACTLY)
        {
            active = currentState == state;
        }
        else if (condition == CONDITION.AFTER)
        {
            active = currentState > state;
        }
        else if (condition == CONDITION.ALWAYS)
        {
            active = true;
        }

        if (!talkChecker.activeSelf)
        {
            hideQuestion();
        }
    }

    public void showArrow()
    {
        if (question && active)
        {
            question.gameObject.SetActive(true);
        }
    }

    public void hideQuestion()
    {
        if (question)
        {
            question.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.range);
    }

    public enum CONDITION
    {
        BEFORE,
        EXACTLY,
        AFTER,
        ALWAYS
    };
}
