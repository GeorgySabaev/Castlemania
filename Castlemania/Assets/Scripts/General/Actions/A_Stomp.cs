using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Stomp : BaseAction
{
    public CharacterMovement movement;
    public A_MeleeAttack attack;

    override public void Invoke()
    {
        attack.Invoke();
        movement.MoveDown();
       
    }
}
