using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class WallTile : Tile
{
    public Sprite[] m_Sprites;
    public Sprite m_Preview;
    public bool connectUp;
    public bool connectRight;

    public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        for (int yd = -1; yd <= 1; yd++)
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                if (HasWallTile(tilemap, position))
                    tilemap.RefreshTile(position);
            }
    }

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        int index = GetIndex(tilemap, location);
        if (index < m_Sprites.Length)
        {
            tileData.sprite = m_Sprites[index];
            tileData.color = Color.white;
            var m = tileData.transform;
            m.SetTRS(Vector3.zero, Quaternion.identity, Vector3.one);
            tileData.transform = m;
            tileData.flags = TileFlags.LockTransform;
            tileData.colliderType = ColliderType.None;
            tileData.gameObject = this.gameObject;
            
        }
        else
        {
            Debug.LogWarning("Not enough sprites in WallTile instance");
        }
    }

    public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject go)
    {
        if (go != null)
        {
            go.GetComponent<GraphTileConnections>().down = ConnectedDown(tilemap, location);
            go.GetComponent<GraphTileConnections>().up = ConnectedUp(tilemap, location);
            go.GetComponent<GraphTileConnections>().left = ConnectedLeft(tilemap, location);
            go.GetComponent<GraphTileConnections>().right = ConnectedRight(tilemap, location);
        }
        return true;
    }

     bool ConnectedDown(ITilemap tilemap, Vector3Int position){
        return (HasWallTile(tilemap, position + new Vector3Int(0, -1, 0)) && (tilemap.GetTile(position + new Vector3Int(0, -1, 0)) as WallTile).connectUp);
    }
     bool ConnectedUp(ITilemap tilemap, Vector3Int position){
        return (connectUp && HasWallTile(tilemap, position + new Vector3Int(0, 1, 0)));
    }
     bool ConnectedRight(ITilemap tilemap, Vector3Int position){
        return (connectRight && HasWallTile(tilemap, position + new Vector3Int(1, 0, 0)));
    }
     bool ConnectedLeft(ITilemap tilemap, Vector3Int position){
        return (HasWallTile(tilemap, position + new Vector3Int(-1, 0, 0)) && (tilemap.GetTile(position + new Vector3Int(-1, 0, 0)) as WallTile).connectRight);
    }
    private int GetIndex(ITilemap tilemap, Vector3Int position)
    {
        int index = 0;
        if (ConnectedUp(tilemap, position)) {
            index += 1;
        }
        if (ConnectedRight(tilemap, position)) {
            index += 2;
        }
        if (ConnectedLeft(tilemap, position)) {
            index += 4;
        }
        return index;
    }

    private bool HasWallTile(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) is WallTile;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/WallTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Wall Tile",
            "New wall Tile",
            "Asset",
            "Save Wall Tile",
            "Assets"
        );
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WallTile>(), path);
    }
#endif
}
