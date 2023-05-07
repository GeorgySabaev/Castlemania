using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    public static Dictionary<string, HashSet<ObjectTracker>> containers =
        new Dictionary<string, HashSet<ObjectTracker>>();
    public string container;

    void Awake()
    {
        if (!containers.ContainsKey(container))
        {
            containers.Add(container, new HashSet<ObjectTracker>());
        }
        containers[container].Add(this);
    }

    void OnDestroy()
    {
        containers[container].Remove(this);
    }
}
