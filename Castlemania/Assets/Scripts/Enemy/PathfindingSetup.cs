using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathfindingSetup : MonoBehaviour
{
    public GraphPathfinder pathfinder;
    public string container;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder.targets = new List<Transform>(ObjectTracker.containers[container].Select((x) => x.transform));
    }
}
