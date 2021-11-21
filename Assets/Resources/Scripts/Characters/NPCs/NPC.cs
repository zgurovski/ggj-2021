using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : ACharacter
{

    public override ICharacterAnimator initCharacterAnimator()
    {
        NPCAnimator npcAnimator = (NPCAnimator)ScriptableObject.CreateInstance(typeof(NPCAnimator));
        npcAnimator.Init(animator);

        return npcAnimator;
    }
}
