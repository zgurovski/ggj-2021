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
    protected CHARACTER_STATE state;
    protected ICharacterAnimator characterAnimator;

    public virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        state = CHARACTER_STATE.IDLE;
        characterAnimator = initCharacterAnimator();
    }

    /**
     * Creates the character animator implementation
     */
    public abstract ICharacterAnimator initCharacterAnimator();

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
    public CHARACTER_STATE getState()
    {
        return this.state;
    }

    /**
     * Sets new state
     */
    public void setState(CHARACTER_STATE newState)
    {
        this.state = newState;
    }

    /**
     * Gets the character animator
     */
    public ICharacterAnimator getCharacterAnimator()
    {
        return this.characterAnimator;
    }
}

/**
 * Represents possible states for the character
 */
public enum CHARACTER_STATE
{
    IDLE,
    MOVING,
    JUMPING,
    PUNCH,
    KICK,
    TALKING,
    TIRED
};