using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //fsm으로 나중에 바꿀 것
    bool isMove = false;
    int targetX, targetY, targetZ;
    public Tilemap map;
    public Tilemap map2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            Moving();
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                map.RefreshAllTiles();
                map2.RefreshAllTiles();

                int x, y, z;
                Vector3 p = new Vector3(point.x, point.y, 1);
                Vector3Int v;
                bool isTile = false;

                x = map2.WorldToCell(p).x;
                y = map2.WorldToCell(p).y;
                z = map2.WorldToCell(p).z;
                v = new Vector3Int(x, y, z);

                if (map2.GetTile(v) == null)
                {
                    p.z = 0;
                    x = map.WorldToCell(point).x;
                    y = map.WorldToCell(point).y;
                    z = map.WorldToCell(point).z;
                    v = new Vector3Int(x, y, z);
                }
                else
                {
                    Debug.LogFormat("{0}, {1}, {2}", x, y, z);

                    SetMove(x, y, z);
                    return;
                }
                if(map.GetTile(v) == null)
                {
                }
                else
                {
                    Debug.LogFormat("{0}, {1}, {2}", x, y, z);

                    SetMove(x, y, z);
                }
            }
        }
    }

    void SetMove(int x, int y, int z)
    {
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
