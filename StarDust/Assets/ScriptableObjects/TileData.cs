using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public enum TileCode
{
    None,
    Ground,
    Obstacle,
    Water,
}

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public TileCode tileCode;
}
