using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : ScriptableObject, ICharacterAnimator
{
    private Animator animator;

    /**
     * Creates ICharacterAnimator implementation using the animator object from the Character
     */
    public void Init(Animator animator)
    {
        this.animator = animator;
    }

    /**
     * Executes the player walk animation
     */
    public void WalkAnimation(Vector2 normalizedDirection)
    {
        animator.SetFloat("Horizontal", normalizedDirection.x);
        animator.SetFloat("Vertical", normalizedDirection.y);
        animator.SetFloat("Speed", normalizedDirection.sqrMagnitude);
    }

    /**
     * Executes the player idle animation
     */
    public void IdleAnimation()
    {
        animator.SetFloat("Speed", 0);
    }
}