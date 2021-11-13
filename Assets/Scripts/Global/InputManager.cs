using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for handling the input events in the game
 */
public class InputManager : MonoBehaviour
{
    [Header("Keyboard controls")]
    public KeyCode MoveLeft = KeyCode.LeftArrow;
    public KeyCode MoveRight = KeyCode.RightArrow;
    public KeyCode MoveUp = KeyCode.UpArrow;
    public KeyCode MoveDown = KeyCode.DownArrow;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Talk = KeyCode.E;

    // Delegates
    public delegate void MovmentHandler(Vector2 direction);
    public static event MovmentHandler onMovementInputEvent;
    public delegate void CombatHandler(string action);
    public static event CombatHandler onCombatInputEvent;

    void Start()
    {
        
    }

    public static void MovementInputEvent(Vector2 direction)
    {
        if (onMovementInputEvent != null) onMovementInputEvent(direction);
    }

    public static void CombatInputEvent(string action)
    {
        if (onCombatInputEvent != null) onCombatInputEvent(action);
    }

    void Update()
    {
        // Movement input
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(MoveLeft)) x = -1f;
        if (Input.GetKey(MoveRight)) x = 1f;
        if (Input.GetKey(MoveUp)) y = 1f;
        if (Input.GetKey(MoveDown)) y = -1f;

        Vector2 direction = new Vector2(x, y);
        MovementInputEvent(direction);

        // Combat input
        if (Input.GetKeyDown(Jump))
        {
            CombatInputEvent("jump");
        }
    }
}
