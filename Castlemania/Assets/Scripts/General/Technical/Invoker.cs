using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Invoker : MonoBehaviour
{
    public static Queue<UnityEvent> queue = new Queue<UnityEvent>();
    public void Update()
    {
        while (queue.Count > 0)
        {
            queue.Dequeue().Invoke();
        }
    }
    public static void Invoke(UnityEvent a){
        queue.Enqueue(a);
    }
}
