using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class A_CompoundAction : BaseAction
{
    public UnityEvent actions = new UnityEvent();
    override public void Invoke()
    {
        actions.Invoke();
    }
}
