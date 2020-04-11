using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EnemyTracking : MonoBehaviour
{
    public Tilemap tilemap;
    public pathfinding pathfinding;
    public Transform Player;
    public int DetectRadius = 3;
    public int MoveRadius;
    public Vector3Int EnemyMapPosition;
    public List<Vector3Int> EnemySight;
    public List<Vector3Int> EnemyMoveRange;
    public bool PlayerIsDetected=false;
    public NextTurn NextTurn;
    // Start is called before the first frame update
    void Start()
    {
        Tilemap[] Tilemaps;
        Tilemaps = GameObject.FindObjectsOfType<Tilemap>();
        for (int i = 0; i < Tilemaps.Length; i++)
        {
            if (Tilemaps[i].tag == "tilemap")
            {
                tilemap = Tilemaps[i];
                break;
            }
        }
        pathfinding = tilemap.GetComponent<pathfinding>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NextTurn = GameObject.FindObjectOfType<Canvas>().GetComponent<NextTurn>();


        EnemyMapPosition = tilemap.WorldToCell(transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        EnemySight= FindPlayer(DetectRadius, EnemyMapPosition);
        EnemyMoveRange = FindPlayer(MoveRadius, EnemyMapPosition);
        foreach(Vector3Int vector in EnemySight)
        {
            if (tilemap.WorldToCell(Player.position)==vector)
            {
                PlayerIsDetected = true;
                break;
            }
            else
            {
                PlayerIsDetected = false;
            }
        }
        
    }

    public void EnemyTurn()
    {
        if(NextTurn.EnemyTurn)
        {
            if(PlayerIsDetected)
            {
                pathfinding.FinDAPath(EnemyMapPosition, Player.position);

            }
        }
    }
    public void EnemyWonder()
    {

    }
    public List<Vector3Int> FindPlayer(int Radius,Vector3Int EnemyMapPosition)
    {

        List<Vector3Int> PositionsInRange = new List<Vector3Int>();

        int DivisionNumDown = Radius / 2;
        int DivisionNumUp = Radius / 2;


        if (EnemyMapPosition.y % 2 == 0 || EnemyMapPosition.y == 0)
        {
            for (int y = -Radius; y <= 0; y++)
            {


                if (y % 2 == 0 || y == 0)
                {

                    for (int x = -(Radius - DivisionNumDown); x <= Radius - DivisionNumDown; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }
                    DivisionNumDown = DivisionNumDown - 1;
                }
                else
                {
                    for (int x = -(Radius - DivisionNumDown); x < Radius - DivisionNumDown; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }
                }
            }
            for (int y = Radius; y > 0; y--)
            {

                if (y % 2 == 0 || y == 0)
                {

                    for (int x = -(Radius - DivisionNumUp); x < Radius + DivisionNumUp - 1; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }
                    DivisionNumUp = DivisionNumUp - 1;
                }
                else
                {
                    for (int x = -(Radius - DivisionNumUp); x < Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }

                }
            }
        }
        else
        {
            for (int y = -Radius; y <= 0; y++)
            {

                Debug.Log("division" + DivisionNumDown);
                if (y % 2 == 0 || y == 0)
                {
                    for (int x = -(Radius - DivisionNumDown); x <= Radius - DivisionNumDown; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }
                    DivisionNumDown = DivisionNumDown - 1;
                }
                else
                {

                    for (int x = -(Radius - DivisionNumDown) + 1; x <= Radius - DivisionNumDown; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }


                }
            }
            for (int y = Radius; y > 0; y--)
            {

                if (y % 2 == 0 || y == 0)
                {
                    for (int x = -(Radius - DivisionNumUp); x <= Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }
                    DivisionNumUp = DivisionNumUp - 1;
                }
                else
                {

                    for (int x = -(Radius - DivisionNumUp) + 1; x <= Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                    }


                }
            }
        }
        return PositionsInRange;
    }

}
