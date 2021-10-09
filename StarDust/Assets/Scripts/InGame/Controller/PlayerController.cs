using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    Hero hero;
    //fsm으로 나중에 바꿀 것
    bool isMove = false;
    int targetX, targetY, targetZ;
    public Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hero.isActive) return;
        if (isMove)
        {
            Moving();
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                Vector3 p = new Vector3(point.x, point.y, 4);
                Vector3Int v;
                do
                {
                    p.z--;
                    v = map.WorldToCell(p);
                }
                while (p.z > 0 && map.GetTile(v) == null);

                if(map.GetTile(v) && map.GetColor(v) == Color.red)
                {
                    Debug.LogFormat("{0}, {1}, {2} Code : {3}", v.x, v.y, v.z, GameManager.Instance.mapManager.GetTileData(v).tileCode);

                    SetMove(v.x, v.y, v.z);
                }
                map.RefreshAllTiles();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                map.RefreshAllTiles();
                Vector3Int position = map.WorldToCell(transform.position + new Vector3(0, 0, -1));
                List<Vector3Int> tiles = GameManager.Instance.mapManager.GetAroundTiles(position, hero.info.movePoint);
                foreach(var tile in tiles)
                {
                    map.SetTileFlags(tile, TileFlags.None);
                    map.SetColor(tile, Color.red);
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                map.RefreshAllTiles();
            }
        }
    }



    void SetMove(int x, int y, int z)
    {
        Vector3Int p = map.WorldToCell(transform.position);
        int moveCount = Mathf.Abs(p.x - x) + Mathf.Abs(p.y - y);
        hero.info.movePoint -= moveCount;
        targetX = x;
        targetY = y;
        targetZ = z;
        isMove = true;
    }

    void Moving()
    {
        transform.position = map.CellToWorld(new Vector3Int(targetX, targetY, targetZ));

        int x = map.WorldToCell(transform.position).x;
        int y = map.WorldToCell(transform.position).y;


        if (x == targetX && y == targetY)
        {
            transform.position = map.CellToWorld(new Vector3Int(targetX, targetY, targetZ + 1));
            isMove = false;
        }
    }
}
