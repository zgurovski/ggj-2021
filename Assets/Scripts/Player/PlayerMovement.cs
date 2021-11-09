using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer GFX;

    [Header("Settings")]
    public float walkSpeed = 22f;
    public float jumpTime = 9f;
    public float jumpHeight = 2.5f;

    public Rigidbody2D rb;

    private PlayerAnimator animator;
    private PlayerState playerState;
    // isTired will be used instead of isDead - when a player loses combat, player gets tired and returns to the neighbourhood
    private bool isTired = false;

    // A list of states where the player can move
    private List<PLAYERSTATE> MovementStates = new List<PLAYERSTATE> {
        PLAYERSTATE.IDLE,
        PLAYERSTATE.MOVING,
        PLAYERSTATE.JUMPING
    };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<PlayerAnimator>();
        playerState = GetComponent<PlayerState>();
    }

    void OnEnable()
    {
        InputManager.onCombatInputEvent += combatInputEvent;
        InputManager.onMovementInputEvent += movementInputEvent;
    }

    void OnDisable()
    {
        InputManager.onCombatInputEvent -= combatInputEvent;
        InputManager.onMovementInputEvent -= movementInputEvent;
    }

    void combatInputEvent(string action)
    {
        if (action == "jump")
        {

        }
    }

    void movementInputEvent(Vector2 dir)
    {
        playerState.isMoving = !dir.Equals(Vector2.zero);

        if (MovementStates.Contains(playerState.currentState) && !isTired)
        {
            // Fake depth by moving slower in y direction
            Vector3 result = new Vector3(dir.x * walkSpeed, dir.y * walkSpeed * .7f, 0);
            
            Move(result);
        }
        else
        {
            // Stop moving
            Move(Vector3.zero);
        }
    }

    private void Move(Vector3 vector)
    {
        // Player object will move only if the player is not currently jumping
        if (playerState.currentState != PLAYERSTATE.JUMPING)
        {
            // Move player
            if (rb != null)
            {
                rb.velocity = vector;
            }

            // Play walk or idle animation
            if (Mathf.Abs(vector.x + vector.y) > 0)
            {
                playerState.SetState(PLAYERSTATE.MOVING);
                animator.Walk();
            }
            else
            {
                playerState.SetState(PLAYERSTATE.IDLE);
                animator.Idle();
            }
        }
    }
}
