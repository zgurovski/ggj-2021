using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public delegate void MovmentHandler(Vector2 dir);
    public static event MovmentHandler onMovementInputEvent;
    public delegate void CombatHandler(string action);
    public static event CombatHandler onCombatInputEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void MovementInputEvent(Vector2 dir)
    {
        if (onMovementInputEvent != null) onMovementInputEvent(dir);
    }

    public static void CombatInputEvent(string action)
    {
        if (onCombatInputEvent != null) onCombatInputEvent(action);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement input
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(MoveLeft)) x = -1f;
        if (Input.GetKey(MoveRight)) x = 1f;
        if (Input.GetKey(MoveUp)) y = 1f;
        if (Input.GetKey(MoveDown)) y = -1f;

        Vector2 dir = new Vector2(x, y);
        MovementInputEvent(dir);

        // Combat input
        if (Input.GetKeyDown(Jump))
        {
            CombatInputEvent("jump");
        }
    }
}
