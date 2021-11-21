using PlayTextSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour, IMove
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
    private NPC npc;
    private List<CHARACTER_STATE> allowedForMovmentStates;
    private IEnumerator moveNpcCoroutine;
    private GameObject talkChecker;

    IEnumerator Start()
    {
        talkChecker = GameObject.FindGameObjectWithTag("TalkChecker");
        npc = GetComponent<NPC>();
        allowedForMovmentStates = getAllowedForMovmentStates();
        currentIterationWaitTime = Random.Range(MinWaitTime, MaxWaitTime);
        nextMovementPoint = getRandomTransportPoint(movementPoints);

        moveNpcCoroutine = MoveNPC(nextMovementPoint.position);
        yield return new WaitForSeconds(secondsBeforeFirstWalk);
        StartCoroutine(moveNpcCoroutine);

        //EventCenter.GetInstance().AddEventListener("NPC.", changeSprite);
        //EventCenter.GetInstance().EventTriggered("Player.FlowerDropped");

        //yield return new WaitForSeconds(secondsBeforeFirstWalk);
        //StartCoroutine(MoveElder(nextMovementPoint.position));
    }

    void FixedUpdate()
    {
        lastTimeMoved += Time.fixedDeltaTime;
    }

    IEnumerator MoveNPC(Vector2 targetPoint) 
    {
        do
        {
            Walk(moveSpeed, targetPoint);
            yield return null;
        } while (npc.getRigidBody().position != targetPoint);

        Idle();
        lastTimeMoved = 0;
        currentIterationWaitTime = Random.Range(MinWaitTime, MaxWaitTime);
        nextMovementPoint = getRandomTransportPoint(movementPoints);

        yield return new WaitForSeconds(currentIterationWaitTime);


        moveNpcCoroutine = MoveNPC(nextMovementPoint.position);
        StartCoroutine(moveNpcCoroutine);

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
        npc.setState(CHARACTER_STATE.IDLE);
        npc.getCharacterAnimator().IdleAnimation();
    }

    public void Walk(float moveSpeed, Vector2 targetPoint)
    {
        if (!allowedForMovmentStates.Contains(npc.getState()))
        {
            return;
        }

        Vector3 resultNormalized = targetPoint - npc.getRigidBody().position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime * moveSpeed);

        npc.getRigidBody().MovePosition(newPosition);

        // Play walk or idle animation
        npc.setState(CHARACTER_STATE.MOVING);
        npc.getCharacterAnimator().WalkAnimation(resultNormalized);
    }

    private Transform getRandomTransportPoint(List<Transform> movementPoints)
    {
        int RandomPointIndex = Random.Range(0, movementPoints.Count);
        return movementPoints[RandomPointIndex];
    }

    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position
     //   Gizmos.color = Color.red;
     //   Gizmos.DrawWireSphere(transform.position, this.approachRange);
    }

    /*

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Idle();
            npc.setState(CHARACTER_STATE.TALKING);
            talkChecker.SetActive(true);

            StopCoroutine(moveNpcCoroutine);

        }
    }

    IEnumerator OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            talkChecker.SetActive(false);
            moveNpcCoroutine = MoveNPC(nextMovementPoint.position);
            yield return new WaitForSeconds(secondsBeforeFirstWalk);
            StartCoroutine(moveNpcCoroutine);

        }
    }
    */
}
