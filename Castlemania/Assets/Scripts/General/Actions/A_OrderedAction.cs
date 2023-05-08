using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class A_OrderedAction : BaseAction
{
    public List<BaseAction> actions;
    override public void Invoke()
    {
        foreach (var action in actions)
        {
            action?.Invoke();
        }
    }
}
