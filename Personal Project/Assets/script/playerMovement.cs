using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class playerMovement : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rg;
    public Vector2 PlayerMove;
    public Tilemap tilemap;
    public Tilemap HighlightTilemap;
    public Transform target;
    public Vector3Int playerMapPosition;
    public Vector3 PlayerCenterPos;
    public pathfinding pathfinding;
    public List<node> Path;

    [Header("the movement is finished")]
    public bool PathFinished=false;



    public List<Vector3Int> PositionsInRange;
    public int Radius = 2;

    public node NextStep;
    [Header("test step")]
    public float timer = 0;
    public float WaitTime = 10f;
    public Vector3 TargetMovement;
    public Vector3 Direction;
    public float Percent;
    public Vector3Int NextStepVector;
    public bool reach = true;
    

    public Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        playerMapPosition = tilemap.WorldToCell(transform.position);
        PlayerCenterPos = tilemap.CellToWorld(playerMapPosition);
        transform.position = PlayerCenterPos;
        //GetMmovementDistance();
        
    }

    // Update is called once per frame
    void Update()
    {

        Path = pathfinding.PathTest;



        WalkOnPath();









    }
    public void WalkOnPath()
    {
        if(Path.Count!=0)
        {
            PathFinished = false;
            if (reach )
            {
                NextStep = Path[0];

                NextStepVector = new Vector3Int(NextStep.position[0], NextStep.position[1], NextStep.position[2]);

                TargetMovement = tilemap.CellToWorld(NextStepVector);
                reach = false;
                
            }


            if (PlayerCenterPos != TargetMovement && reach == false)
            {
                //transform.position = Vector3.Lerp(PlayerCenterPos, TargetMovement, Time.deltaTime * speed);
                transform.position = Vector3.MoveTowards(PlayerCenterPos, TargetMovement, 0.03f);

            }
            
            else
            {
                
                reach = true;
                Path.RemoveAt(0);
                
            }
            
            PlayerCenterPos = transform.position;
        }
        else
        {
            PathFinished = true;
        }
       
       
    }


    public void GetMmovementDistance()
    {
        PositionsInRange = new List<Vector3Int>();
        
        int DivisionNumDown = Radius / 2;
        int DivisionNumUp = Radius / 2;

        
        if (playerMapPosition.y % 2 == 0 || playerMapPosition.y == 0)
        {
            for (int y=-Radius;y<=0;y++)
            {
                
                
                if (y%2==0||y==0)
                {
                    
                    for(int x=-(Radius-DivisionNumDown);x<=Radius-DivisionNumDown;x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                    DivisionNumDown = DivisionNumDown - 1;
                }
                else
                {
                    for(int x = -(Radius - DivisionNumDown); x < Radius - DivisionNumDown; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                }
            }
            for (int y = Radius; y > 0; y--)
            {
                
                if (y % 2 == 0 || y == 0)
                {

                    for (int x = -(Radius - DivisionNumUp)+1; x < Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                    
                }
                else
                {
                    for (int x = -(Radius - DivisionNumUp); x < Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                    DivisionNumUp = DivisionNumUp - 1;
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
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                    DivisionNumDown = DivisionNumDown - 1;
                }
                else
                {

                    for (int x = -(Radius-DivisionNumDown)+1 ; x <= Radius-DivisionNumDown; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                    

                }
            }
            for (int y = Radius; y > 0; y--)
            {

                if (y % 2 == 0 || y == 0)
                {
                    for (int x = -(Radius - DivisionNumUp); x <= Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }
                    DivisionNumUp = DivisionNumUp - 1;
                }
                else
                {

                    for (int x = -(Radius - DivisionNumUp) + 1; x <= Radius - DivisionNumUp; x++)
                    {
                        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
                    }

                   
                }
            }
        }
    
        

        foreach (Vector3Int vector in PositionsInRange)
        {
            HighlightTilemap.SetTile(vector, tile);
        }

    }
}
