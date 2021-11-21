using PlayTextSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheElderMovement : MonoBehaviour, IMove
{
   
    public float moveSpeed = 10f;
    public float MinWaitTime = 3f;
    public float MaxWaitTime = 10f;
    public float secondsBeforeFirstWalk = 3f;
    public List<Transform> movementPoints;
    public float currentIterationWaitTime;
    public float lastTimeMoved = 0;
    public Transform nextMovementPoint;
    public float approachRange = 6;
    private TheElder elder;
    private List<CHARACTER_STATE> allowedForMovmentStates;
    private bool firstTalkWithPlayer = false;
    private Player player;
    private IEnumerator moveElderCoroutine;

    IEnumerator Start()
    {
        elder = GetComponent<TheElder>();
        allowedForMovmentStates = getAllowedForMovmentStates();
        currentIterationWaitTime = Random.Range(MinWaitTime, MaxWaitTime);
        nextMovementPoint = getRandomTransportPoint(movementPoints);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        moveElderCoroutine = MoveElder(nextMovementPoint.position);
        yield return new WaitForSeconds(secondsBeforeFirstWalk);
        StartCoroutine(moveElderCoroutine);

        //EventCenter.GetInstance().AddEventListener("TheElderMovement.", changeSprite);
        //EventCenter.GetInstance().EventTriggered("Player.FlowerDropped");

        //yield return new WaitForSeconds(secondsBeforeFirstWalk);
        //StartCoroutine(MoveElder(nextMovementPoint.position));
    }

    void FixedUpdate()
    {
        lastTimeMoved += Time.fixedDeltaTime;
    }

    void Update()
    {

    }

    IEnumerator MoveElder(Vector2 targetPoint) 
    {
        do
        {
            if (!firstTalkWithPlayer)
            {
                float distance = Vector3.Distance(this.transform.position, player.transform.position);

                if (distance < approachRange)
                {
                    targetPoint = player.transform.position;
                }
            }

            Walk(moveSpeed, targetPoint);
            yield return null;
        } while (elder.getRigidBody().position != targetPoint);

        Idle();
        lastTimeMoved = 0;
        currentIterationWaitTime = Random.Range(MinWaitTime, MaxWaitTime);
        nextMovementPoint = getRandomTransportPoint(movementPoints);

        yield return new WaitForSeconds(currentIterationWaitTime);


        moveElderCoroutine = MoveElder(nextMovementPoint.position);
        StartCoroutine(moveElderCoroutine);

        //StartCoroutine(MoveElder(nextMovementPoint.position));
    }

    public List<CHARACTER_STATE> getAllowedForMovmentStates()
    {
        return new List<CHARACTER_STATE> {
            CHARACTER_STATE.IDLE,
            CHARACTER_STATE.MOVING
        };
    }

    public void Idle()
    {
        elder.setState(CHARACTER_STATE.IDLE);
        elder.getCharacterAnimator().IdleAnimation();
    }

    public void Walk(float moveSpeed, Vector2 targetPoint)
    {
        if (!allowedForMovmentStates.Contains(elder.getState()))
        {
            return;
        }

        Vector3 resultNormalized = targetPoint - elder.getRigidBody().position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime * moveSpeed);

        elder.getRigidBody().MovePosition(newPosition);

        // Play walk or idle animation
        elder.setState(CHARACTER_STATE.MOVING);
        elder.getCharacterAnimator().WalkAnimation(resultNormalized);
    }

    private Transform getRandomTransportPoint(List<Transform> movementPoints)
    {
        int RandomPointIndex = Random.Range(0, movementPoints.Count);
        return movementPoints[RandomPointIndex];
    }

    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.approachRange);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!firstTalkWithPlayer && collision.gameObject.tag == "Player")
        {
            Idle();
            elder.setState(CHARACTER_STATE.TALKING);

            StopCoroutine(moveElderCoroutine);

            firstTalkWithPlayer = true;
            EventCenter.GetInstance().EventTriggered("PlayText.Play", this.GetComponent<InteractableGraph>().GetGraph());
        }
    }
}
