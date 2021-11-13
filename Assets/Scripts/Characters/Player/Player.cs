using System.Collections.Generic;
using UnityEngine;

/**
 * Player
 */
public class Player : ACharacter, IMove
{
    public float moveSpeed = 1f;

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

    void movementInputEvent(Vector2 direction)
    {
        bool isMoving = !direction.Equals(Vector2.zero);

        if (state != STATE.TIRED && getAllowedForMovmentStates().Contains(state))
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

    public override ICharacterAnimator getCharacterAnimator()
    {
        PlayerAnimator playerAnimator = (PlayerAnimator)ScriptableObject.CreateInstance(typeof(PlayerAnimator));
        playerAnimator.Init(animator);

        return playerAnimator;
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
        setState(STATE.IDLE);
        characterAnimator.IdleAnimation();
    }

    public void Walk(float moveSpeed, Vector2 direction)
    {
        if (state != STATE.JUMPING)
        {
            // Fake depth by moving slower in y direction
            Vector2 result = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed * .7f);

            // Move player
            rigidBody.MovePosition(rigidBody.position + direction * Time.fixedDeltaTime);

            // Play walk or idle animation
            setState(STATE.MOVING);
            characterAnimator.WalkAnimation(result.normalized);
        }
    }
}
