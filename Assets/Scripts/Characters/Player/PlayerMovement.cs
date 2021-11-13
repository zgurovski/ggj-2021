using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    public float moveSpeed = 1f;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void OnEnable()
    {
        InputManager.onMovementInputEvent += movementInputEvent;
    }

    void OnDisable()
    {
        InputManager.onMovementInputEvent -= movementInputEvent;
    }

    void movementInputEvent(Vector2 direction)
    {
        bool isMoving = !direction.Equals(Vector2.zero);

        if (player.getState() != STATE.TIRED && getAllowedForMovmentStates().Contains(player.getState()))
        {
            // Start walking
            Walk(moveSpeed, direction);
        }
        if (!isMoving)
        {
            // Stop walking
            Idle();
        }
    }

    public List<STATE> getAllowedForMovmentStates()
    {
        return new List<STATE> {
            STATE.IDLE,
            STATE.MOVING,
            STATE.JUMPING
        };
    }

    public void Idle()
    {
        player.setState(STATE.IDLE);
        player.getCharacterAnimator().IdleAnimation();
    }

    public void Walk(float moveSpeed, Vector2 direction)
    {
        if (player.getState() != STATE.JUMPING)
        {
            // Fake depth by moving slower in y direction
            Vector2 result = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed * .7f);

            // Move player
            player.getRigidBody().MovePosition(player.getRigidBody().position + direction * Time.fixedDeltaTime);

            // Play walk or idle animation
            player.setState(STATE.MOVING);
            player.getCharacterAnimator().WalkAnimation(result.normalized);
        }
    }
}
