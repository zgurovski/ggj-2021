using System.Collections.Generic;
using UnityEngine;

/**
 * Player
 */
public class Player : ACharacter
{

    public override void Start()
    {
        base.Start();
        this.gameObject.AddComponent<PlayerMovement>();
    }

    public override ICharacterAnimator initCharacterAnimator()
    {
        PlayerAnimator playerAnimator = (PlayerAnimator)ScriptableObject.CreateInstance(typeof(PlayerAnimator));
        playerAnimator.Init(animator);

        return playerAnimator;
    }
}