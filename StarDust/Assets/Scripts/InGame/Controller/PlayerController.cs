using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //fsm으로 나중에 바꿀 것
    bool isMove = false;
    int targetX, targetY, targetZ;
    Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
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

                int x, y, z;
                x = map.WorldToCell(point).x;
                y = map.WorldToCell(point).y;
                z = map.WorldToCell(point).z;

                Debug.LogFormat("{0}, {1}, {2}", x, y, z);

                SetMove(x, y, z);
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
        transform.position = map.CellToWorld(new Vector3Int(targetX, targetY, 0));

        int x = map.WorldToCell(transform.position).x;
        int y = map.WorldToCell(transform.position).y;

        if (x == targetX && y == targetY)
        {
            transform.position = map.CellToWorld(new Vector3Int(targetX, targetY, 1));
            isMove = false;
        }
    }
}
