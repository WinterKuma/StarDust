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

                Vector3 p = new Vector3(point.x, point.y, 4);
                Vector3Int v;
                do
                {
                    p.z--;
                    v = map.WorldToCell(p);
                }
                while (p.z > 0 && map.GetTile(v) == null);

                if(map.GetTile(v))
                {
                    Debug.LogFormat("{0}, {1}, {2} Code : {3}", v.x, v.y, v.z, GameManager.Instance.mapManager.GetTileData(v).tileCode);

                    SetMove(v.x, v.y, v.z);
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
