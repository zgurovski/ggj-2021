using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script decides the order of imporance of playerstates.
// For Example you can't attack if you are being hit, therefore an attack state while your are hit is ignored
public class PlayerState : MonoBehaviour
{
    public PLAYERSTATE currentState = PLAYERSTATE.IDLE;
    public bool isMoving = false;
    public float combatDistance;

    public void SetState(PLAYERSTATE state)
    {
        currentState = state;
    }
}
public enum PLAYERSTATE
{
    IDLE,
    MOVING,
    JUMPING,
    PUNCH,
    KICK,
    TALKING,
};