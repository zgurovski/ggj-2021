using UnityEngine;

/**
 * Used to define abstraction of animation methods that a character will use in the game
 */
public interface ICharacterAnimator
{
    /**
     * Trigger a walk animation using a normalized Vector2 as a direction
     */
    void WalkAnimation(Vector2 normalizedDirection);
    /**
     * Trigger an idle animation for
     */
    void IdleAnimation();
}
