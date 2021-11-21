using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for handling the input events in the game
 */
public class InputManager : MonoBehaviour
{
    [Header("Keyboard controls")]
    public static KeyCode MoveLeft = KeyCode.LeftArrow;
    public static KeyCode MoveRight = KeyCode.RightArrow;
    public static KeyCode MoveUp = KeyCode.UpArrow;
    public static KeyCode MoveDown = KeyCode.DownArrow;
    public static KeyCode Jump = KeyCode.Space;
    public static KeyCode Talk = KeyCode.E;

    // Delegates
    public delegate void CombatHandler(string action);
    public static event CombatHandler onCombatInputEvent;

    void Start()
    {
        
    }


    public static void CombatInputEvent(string action)
    {
        if (onCombatInputEvent != null) onCombatInputEvent(action);
    }

    void Update()
    {
        
        // Combat input
        if (Input.GetKeyDown(Jump))
        {
            CombatInputEvent("jump");
        }
    }
}
