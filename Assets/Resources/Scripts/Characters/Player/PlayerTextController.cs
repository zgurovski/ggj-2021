using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextController : MonoBehaviour
{
    private InteractableGraph[] interactables;
    private GameObject talkChecker;
    private TalkingManager talkManager;
    private float distance;
    public InteractableGraph closest;
    private Player player;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        this.interactables = GameObject.FindObjectsOfType<InteractableGraph>();
        this.talkChecker = GameObject.FindGameObjectWithTag("TalkChecker");
        this.talkManager = GameObject.FindObjectOfType<TalkingManager>();
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        this.playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Hacky disable of player movement if speaking
        playerMovement.enabled = talkChecker.activeSelf;

        InteractableGraph newClosest = null;
        float closestDistance = 999999f;
        foreach (var interactable in this.interactables)
        {
            float distance = Vector3.Distance(this.transform.position, interactable.transform.position);
           // if (interactable.name == "Babushka")
          //  {
               // Debug.Log("deiba mama ti deeba");
                // Don't delete this empty if. Babusha's object breaks without it and we don't know why.
                // Shrodinger's bug of observability.
          //  }

            if (distance < closestDistance && distance < interactable.range && interactable.active)
            {
                newClosest = interactable;
                closestDistance = distance;
            }
        }

        setClosest(newClosest);
    }

    void setClosest(InteractableGraph newClosest)
    {
        if (newClosest == this.closest)
        {
            // same target do nothing
            return;
        }

        if (this.closest != null)
        {
            // remove arrow from old target (if we had one)
            this.closest.hideQuestion();
        }

        if (newClosest != null)
        {
            // add arrow to new target (if we have one)
            newClosest.showArrow();
        }

        // set current target and current graph
        this.talkManager.Graph = newClosest ? newClosest.GetGraph() : null;
        this.closest = newClosest;
    }
}
