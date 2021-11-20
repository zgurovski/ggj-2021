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
    private TheElder elder;
    private List<CHARACTER_STATE> allowedForMovmentStates;
    private delegate IEnumerator MovmentHandler(Vector2 direction);
    private event MovmentHandler elderMovementDelegate;
    public float currentIterationWaitTime;
    public float lastTimeMoved = 0;
    public Transform nextMovementPoint;

    IEnumerator Start()
    {
        elder = GetComponent<TheElder>();
        allowedForMovmentStates = getAllowedForMovmentStates();
        currentIterationWaitTime = Random.Range(MinWaitTime, MaxWaitTime);
        nextMovementPoint = getRandomTransportPoint(movementPoints);

        yield return new WaitForSeconds(secondsBeforeFirstWalk);
        StartCoroutine(MoveElder(nextMovementPoint.position));
    }

    void OnEnable()
    {
        elderMovementDelegate += MoveElder;
    }

    void OnDisable()
    {
        elderMovementDelegate -= MoveElder;
    }

    void FixedUpdate()
    {
        lastTimeMoved += Time.fixedDeltaTime;
    }

    IEnumerator MoveElder(Vector2 targetPoint) 
    {
        do
        {
            Walk(moveSpeed, targetPoint);
            yield return null;
        } while (elder.transform.position.x != targetPoint.x || elder.transform.position.y != targetPoint.y);

        Idle();
        lastTimeMoved = 0;
        yield return new WaitForSeconds(currentIterationWaitTime);
        
        currentIterationWaitTime = Random.Range(MinWaitTime, MaxWaitTime);
        nextMovementPoint = getRandomTransportPoint(movementPoints);
        StartCoroutine(MoveElder(nextMovementPoint.position));
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
}
