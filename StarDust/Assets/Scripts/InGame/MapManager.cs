using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var data in tileDatas)
        {
            foreach(var tile in data.tiles)
            {
                dataFromTiles.Add(tile, data);
            }
        }
    }

    public TileData GetTileData(Vector3Int position)
    {
        TileBase tile = map.GetTile(position);
        if (tile == null) return null;
        if (dataFromTiles.ContainsKey(tile))
            return dataFromTiles[tile];
        else
            return null;
    }

    public TileData GetTileData(TileBase tile)
    {
        if (tile == null) return null;
        if (dataFromTiles.ContainsKey(tile))
            return dataFromTiles[tile];
        else
            return null;
    }

    public List<Vector3Int> GetAroundTiles(Vector3Int position, int distance)
    {
        List<Vector3Int> tiles = new List<Vector3Int>();

        GetAroundTiles(tiles, position, distance);

        return tiles;
    }

    //Movement Around
    private List<Vector3Int> GetAroundTiles(List<Vector3Int> list, Vector3Int position, int distance)
    {
        TileBase tile = map.GetTile(position);
        if (tile != null && !list.Contains(position))
        {
            list.Add(position);
        }

        Vector3Int left = position + new Vector3Int(-1, 0, 0);
        Vector3Int top = position + new Vector3Int(0, 1, 0);
        Vector3Int right = position + new Vector3Int(1, 0, 0);
        Vector3Int bottom = position + new Vector3Int(0, -1, 0);

        left = GetTilePos(left, 2, left.z - 4);
        top = GetTilePos(top, 2, top.z - 4);
        right = GetTilePos(right, 2, right.z - 4);
        bottom = GetTilePos(bottom, 2, bottom.z - 4);
        
        //tile = map.GetTile(left);
        //if (tile && !list.Contains(left))
        //{
        //    list.Add(left);
        //}
        //tile = map.GetTile(top);
        //if (tile && !list.Contains(top))
        //{
        //    list.Add(top);
        //}
        //tile = map.GetTile(right);
        //if (tile && !list.Contains(right))
        //{
        //    list.Add(right);
        //}
        //tile = map.GetTile(bottom);
        //if (tile && !list.Contains(bottom))
        //{
        //    list.Add(bottom);
        //}

        if (distance > 0)
        {
            GetAroundTiles(list, left, distance - 1);
            GetAroundTiles(list, top, distance - 1);
            GetAroundTiles(list, right, distance - 1);
            GetAroundTiles(list, bottom, distance - 1);
        }

        return list;
    }

    public Vector3Int GetTilePos(Vector3Int position, int maxY, int minY =  0)
    {
        Vector3Int vector = position + new Vector3Int(0, 0, maxY);

        while (vector.z > minY && map.GetTile(vector) == null)
        {
            //-2로 대채할것
            vector.z--;
        }

        return vector;
    }
}
