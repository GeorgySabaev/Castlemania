using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PlayAnimation : MonoBehaviour, IAction
{
    public Animator animator;
    public string state;
    
    public void Invoke(){
        animator.Play(state);
    }
}
