using System.Collections.Generic;
using UnityEngine;

/**
 * Used to define methods to move a GameObject
 */
public interface IMove
{
    /**
     * Gets all character states that allow the character to move
     */
    public List<CHARACTER_STATE> getAllowedForMovmentStates();

    /**
     * Stop moving the game object
     */
    public void Idle();

    /**
     * Move the character towards direction and using speed
     */
    public void Walk(float moveSpeed, Vector2 direction);
}
