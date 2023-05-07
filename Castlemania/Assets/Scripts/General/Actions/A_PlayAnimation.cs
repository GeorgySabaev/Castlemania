using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PlayAnimation : BaseAction
{
    public Animator animator;
    public string state;
    
    override public void Invoke(){
        animator.Play(state);
    }
}
