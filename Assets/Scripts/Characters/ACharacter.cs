using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public abstract class ACharacter : MonoBehaviour
{
    [Header("Settings")]
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected STATE state;
    protected ICharacterAnimator characterAnimator;

    public virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        state = STATE.IDLE;
        characterAnimator = getCharacterAnimator();
    }

    /**
     * Creates the character animator implementation
     */
    public abstract ICharacterAnimator getCharacterAnimator();

    /**
     * Gets the character rigidBody
     */
    public Rigidbody2D getRigidBody()
    {
        return this.rigidBody;
    }

    /**
     * Gets the character sprite renderer component
     */
    public SpriteRenderer getSpriteRenderer()
    {
        return this.spriteRenderer;
    }

    /**
     * Gets the character animator compoment
     */
    public Animator getAnimator()
    {
        return this.animator;
    }

    /**
     * Gets character current state
     */
    protected STATE getState()
    {
        return this.state;
    }

    /**
     * Sets new state
     */
    protected void setState(STATE newState)
    {
        this.state = newState;
    }
}

/**
 * Represents possible states for the character
 */
public enum STATE
{
    IDLE,
    MOVING,
    JUMPING,
    PUNCH,
    KICK,
    TALKING,
    TIRED
};