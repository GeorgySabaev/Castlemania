using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPathfinder : MonoBehaviour
{
    public List<Transform> targets;
    GraphManager graph;

    public void Start()
    {
        graph = GraphManager.instance;
    }

    public Vector2Int Pathfind(Vector3Int location)
    // modified BFS
    {
        TargetCleanup();
        // setup
        HashSet<Vector3Int> used = new HashSet<Vector3Int>();
        Queue<KeyValuePair<Vector3Int, Vector3Int>> queue =
            new Queue<KeyValuePair<Vector3Int, Vector3Int>>();
        HashSet<Vector3Int> targets = GetTargetPositions();
        if (targets.Contains(location))
        {
            return new Vector2Int(0, 0);
        }
        used.Add(location);
        foreach (Vector3Int neighbour in GetAdjacentTiles(location))
        {
            if (targets.Contains(neighbour))
            {
                return new Vector2Int(neighbour.x - location.x, neighbour.y - location.y);
            }
            queue.Enqueue(new KeyValuePair<Vector3Int, Vector3Int>(neighbour, neighbour));
            used.Add(neighbour);
        }
        // main loop
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            foreach (var next in GetAdjacentTiles(curr.Value))
            {
                if (used.Contains(next))
                {
                    continue;
                }
                if (targets.Contains(next))
                {
                    return new Vector2Int(curr.Key.x - location.x, curr.Key.y - location.y);
                }
                queue.Enqueue(new KeyValuePair<Vector3Int, Vector3Int>(curr.Key, next));
                used.Add(next);
            }
        }
        Debug.LogWarning($"Target not found by {gameObject.name}'s GraphPathfinder!");
        return new Vector2Int(0, 0);
    }
    private void TargetCleanup()
    {
        targets = new List<Transform>(targets.Where((X) => X));
    }

    private HashSet<Vector3Int> GetTargetPositions()
    {
        return new HashSet<Vector3Int>(targets.Select((x) => graph.GetCoordinates(x.position)));
    }

    private List<Vector3Int> GetAdjacentTiles(Vector3Int location)
    {
        List<Vector3Int> retval = new List<Vector3Int>();
        if (graph.ConnectedDown(location))
        {
            retval.Add(location + new Vector3Int(0, -1, 0));
        }
        if (graph.ConnectedUp(location))
        {
            retval.Add(location + new Vector3Int(0, 1, 0));
        }
        if (graph.ConnectedLeft(location))
        {
            retval.Add(location + new Vector3Int(-1, 0, 0));
        }
        if (graph.ConnectedRight(location))
        {
            retval.Add(location + new Vector3Int(1, 0, 0));
        }
        return retval;
    }
}
