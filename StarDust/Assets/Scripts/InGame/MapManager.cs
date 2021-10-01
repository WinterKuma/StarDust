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
}
