using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*public SpriteRenderer GFX;

    [Header("Settings")]
    public float moveSpeed = 22f;
    public float jumpTime = 9f;
    public float jumpHeight = 2.5f;

    public Rigidbody2D rb;

    private PlayerAnimator animator;
    private PlayerState playerState;
    // isTired will be used instead of isDead - when a player loses combat, player gets tired and returns to the neighbourhood
    private bool isTired = false;
    private Vector2 movement = Vector2.zero;

    // A list of states where the player can move
    private List<PLAYERSTATE> MovementStates = new List<PLAYERSTATE> {
        PLAYERSTATE.IDLE,
        PLAYERSTATE.MOVING,
        PLAYERSTATE.JUMPING
    };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<PlayerAnimator>();
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
            // Move player
            Move(dir);
        }
        if (!playerState.isMoving)
        {
            // Stop moving
            playerState.SetState(PLAYERSTATE.IDLE);
            animator.Idle();
        }
    }

    private void Move(Vector2 dir)
    {
        // Player object will move only if the player is not currently jumping
        if (playerState.currentState != PLAYERSTATE.JUMPING)
        {
            // Fake depth by moving slower in y direction
            Vector2 result = new Vector3(dir.x * moveSpeed, dir.y * moveSpeed * .7f);

            // Move player
            rb.MovePosition(rb.position + dir * Time.fixedDeltaTime);

            // Play walk or idle animation
            playerState.SetState(PLAYERSTATE.MOVING);
            animator.Walk(result.normalized);
        }
    }*/
}
