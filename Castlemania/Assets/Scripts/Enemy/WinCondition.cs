using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    public static WinCondition instance;
    public UnityEvent OnWin = new UnityEvent();

    public void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        instance = this;
    }
}
