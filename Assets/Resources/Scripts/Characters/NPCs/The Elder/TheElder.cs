using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheElder : ACharacter
{

    public override ICharacterAnimator initCharacterAnimator()
    {
        TheElderAnimator elderAnimator = (TheElderAnimator)ScriptableObject.CreateInstance(typeof(TheElderAnimator));
        elderAnimator.Init(animator);

        return elderAnimator;
    }
}
