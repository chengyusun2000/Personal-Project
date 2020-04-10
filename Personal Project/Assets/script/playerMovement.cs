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
    public Transform target;
    public Vector3Int playerMapPosition;
    public Vector3 PlayerCenterPos;
    public pathfinding pathfinding;
    public List<node> Path;




    public List<Vector3Int> PositionsInRange;
    public int Radius;

    public node NextStep;
    [Header("test step")]
    public float timer = 0;
    public float WaitTime = 10f;
    public Vector3 TargetMovement;
    public Vector3 Direction;
    public float Percent;
    public Vector3Int NextStepVector;
    private bool reach = true;
    public int i = 0;

    public Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        playerMapPosition = tilemap.WorldToCell(transform.position);
        PlayerCenterPos = tilemap.CellToWorld(playerMapPosition);
        transform.position = PlayerCenterPos;
        GetMmovementDistance();
        
    }

    // Update is called once per frame
    void Update()
    {

        Path = pathfinding.PathTest;

        

        //WalkOnPath();
        
        
        
            
     
        
       

        
    }
    public void WalkOnPath()
    {
        if (reach&&i<Path.Count)
        {
            NextStep = Path[i];

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
            i++;
        }
        PlayerCenterPos = transform.position;
    }


    public void GetMmovementDistance()
    {
        PositionsInRange = new List<Vector3Int>();
        Radius = 5;
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
    
        //if(playerMapPosition.y%2==0||playerMapPosition.y==0)
        //{
        //    for (int y = -Radius; y <= 0; y++)
        //    {
        //        if(y%2==0||y==0)
        //        {
        //            for (int x = Mathf.Max(-Radius, y - Radius); x <= Mathf.Min(Radius, y + Radius); x++)
        //            {

        //                PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x+1, playerMapPosition.y + y, playerMapPosition.z));
        //            }

        //        }
        //        else
        //        {
        //            for (int x = Mathf.Max(-Radius, y - Radius); x <= Mathf.Min(Radius, y + Radius); x++)
        //            {

        //                PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
        //            }
        //            //for (int x = Mathf.Max(-Radius, -y - Radius); x <= Mathf.Min(Radius, -y + Radius); x++)
        //            //{
        //            //    PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
        //            //}
        //        }

        //    }
        //    //for(int y=Radius;y>0;y--)
        //    //{
        //    //    for (int x = Mathf.Max(-Radius, -y - Radius); x <= Mathf.Min(Radius, -y + Radius); x++)
        //    //    {
        //    //        PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
        //    //    }
        //    //}
        //}
        //else
        //{
        //    for (int y = -Radius; y <= 0; y++)
        //    {
        //        for (int x = Mathf.Max(-Radius, -y - Radius); x <= Mathf.Min(Radius, -y + Radius); x++)
        //        {
        //            PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
        //        }
        //    }
        //    for (int y = Radius; y > 0; y--)
        //    {
        //        for (int x = Mathf.Max(-Radius, y - Radius); x <= Mathf.Min(Radius, y + Radius); x++)
        //        {

        //            PositionsInRange.Add(new Vector3Int(playerMapPosition.x + x, playerMapPosition.y + y, playerMapPosition.z));
        //        }
        //    }

        //}


        foreach (Vector3Int vector in PositionsInRange)
        {
            tilemap.SetTile(vector, tile);
        }

    }
}
