using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphManager : MonoBehaviour
{
    public static GraphManager instance;
    public Tilemap tilemap;

    public void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        instance = this;
    }

    public bool ConnectedLeft(Vector3Int position)
    {
        return tilemap.GetInstantiatedObject(position).GetComponent<GraphTileConnections>().left;
    }

    public bool ConnectedUp(Vector3Int position)
    {
        return tilemap.GetInstantiatedObject(position).GetComponent<GraphTileConnections>().up;
    }

    public bool ConnectedRight(Vector3Int position)
    {
        return tilemap.GetInstantiatedObject(position).GetComponent<GraphTileConnections>().right;
    }

    public bool ConnectedDown(Vector3Int position)
    {
        return tilemap.GetInstantiatedObject(position).GetComponent<GraphTileConnections>().down;
    }

    public Vector3Int GetCoordinates(Vector3 position)
    {
        return tilemap.layoutGrid.WorldToCell(position);
    }
}
