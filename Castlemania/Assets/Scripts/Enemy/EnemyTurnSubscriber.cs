using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTurnSubscriber : MonoBehaviour
{
    public UnityEvent action;
    public void Start()
    {
        Clock.instance.PostBeatResolves.AddListener(action.Invoke);
    }
}
