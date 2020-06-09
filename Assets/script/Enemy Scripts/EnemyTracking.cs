using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EnemyTracking : MonoBehaviour
{
    [Header("references")]
    public Tilemap tilemap;
    public pathfinding pathfinding;
    public Transform Player;
    public Tilemap HighLight;
    public Tile tile;
    public Load load;

    [Header("MovementElements")]
    public int DetectRadius = 3;
    public int MoveRadius;
    public Vector3Int EnemyMapPosition;
    public List<Vector3Int> EnemySight;
    public List<Vector3Int> EnemyMoveRange;
    public List<node> EnemyToPlayer;
    public List<Vector3Int> Tem;
    [SerializeField] private bool CheckInRange = true;
    public bool PlayerIsDetected=false;

    [Header("EnemyMoveCondition")]
    private  bool PathFinished = true;
    public  bool reach = true;
    private Vector3Int NextStep;
    private int RandonNumber;
    public LayerMask linemask;
    private List<node> Path;
    [Header("NextTurn")]
    private bool NextTurn = false;
    private bool OnlyOnce = false;
    [SerializeField]private bool TurnFinished = false;
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
        load = tilemap.GetComponent<Load>();
        pathfinding = tilemap.GetComponent<pathfinding>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Tilemap[] tilemaps;
        tilemaps= GameObject.FindObjectsOfType<Tilemap>();
        for (int i = 0; i < tilemaps.Length; i++)
        {
            if (tilemaps[i].tag == "HighLight")
            {
                HighLight = tilemaps[i];
                break;
            }
        }

        EnemyMapPosition = tilemap.WorldToCell(transform.position);

        transform.position = tilemap.CellToWorld(EnemyMapPosition);
        

    }

    // Update is called once per frame
    void Update()
    {
        EnemySight= FindPlayer(DetectRadius, EnemyMapPosition);//get enemy sight
        EnemyMoveRange = FindPlayer(MoveRadius, EnemyMapPosition);//get enemy move range
        if(PathFinished)//when enenmy stop the movement, highlight tiles
        {
            foreach (Vector3Int vector in EnemyMoveRange)
            {
                HighLight.SetTile(vector, tile);
            }
        }
        else
        {
            foreach (Vector3Int vector in EnemyMoveRange)
            {
               HighLight.SetTile(vector, null);
            }
        }
        




        
        EnemyTurn();
    }

    public void EnemyTurn()//all the steps enemy will do in enenmy turn
    {
        if(NextTurn)
        {
            
            if (CheckInRange)
            {
                foreach (Vector3Int vector in EnemySight)// if player is in sight area, player is detected
                {
                    if (tilemap.WorldToCell(Player.position) == vector)
                    {
                        PlayerIsDetected = true;
                        break;
                    }
                    else
                    {
                        PlayerIsDetected = false;
                    }
                }
                CheckInRange = false;
            }
            
            if (PlayerIsDetected)
            {
                if( !OnlyOnce)
                {
                    EnemyToPlayer = pathfinding.FinDAPath(tilemap.CellToWorld(EnemyMapPosition), Player.position);
                    for (int i = 0; i < EnemyToPlayer.Count; i++)
                    {
                        for (int x = 0; x < EnemyMoveRange.Count; x++)
                        {
                            if (new Vector3Int(EnemyToPlayer[i].position[0], EnemyToPlayer[i].position[1], EnemyToPlayer[i].position[2]) == EnemyMoveRange[x])
                            {
                                Tem.Add(EnemyMoveRange[x]);
                            }
                        }
                    }

                    OnlyOnce = true;
                    
                }
                EnemyMove();//enemy move towards player
            }
            else
            {
                EnemyWonder();
            }
        }
       
    }



    public void EnemyWonder()//enemy chooses a random position in the moveposition and move to it
    {
        
        if(!OnlyOnce)
        {
            RandonNumber = Random.Range(0, EnemyMoveRange.Count - 1);
            Path = pathfinding.FinDAPath(tilemap.CellToWorld(EnemyMapPosition), tilemap.CellToWorld(EnemyMoveRange[RandonNumber]));//use a* pathfinding to get a path
            OnlyOnce = true;
        }

        //NextStep = new Vector3Int(Path[0].position[0], Path[0].position[1], Path[0].position[2]);
        //transform.position = Vector3.MoveTowards(transform.position, tilemap.CellToWorld(NextStep), 0.03f);
        //EnemyMapPosition = tilemap.WorldToCell(transform.position);
        //EnemyMapPosition = EnemyMoveRange[RandonNumber];
        //transform.position = tilemap.CellToWorld(EnemyMapPosition);


        if (Path.Count != 0)
        {
            PathFinished = false;
            if (reach)
            {
                NextStep = new Vector3Int(Path[0].position[0], Path[0].position[1], Path[0].position[2]);





                reach = false;

            }


            if (transform.position != tilemap.CellToWorld(NextStep) && reach == false)
            {
                //transform.position = Vector3.Lerp(PlayerCenterPos, TargetMovement, Time.deltaTime * speed);
                transform.position = Vector3.MoveTowards(transform.position, tilemap.CellToWorld(NextStep), 1.3f*Time.deltaTime);

            }





            else
            {

                reach = true;

                Path.RemoveAt(0);


            }

            EnemyMapPosition = tilemap.WorldToCell(transform.position);
        }
        else
        {
            TurnFinished = true;
            PathFinished = true;
            NextTurn = false;
            OnlyOnce = false;
            CheckInRange = true;
        }
    }




    public void EnemyMove()
    {
        if (Tem.Count != 0)
        {
            PathFinished = false;
            if (reach)
            {
                NextStep = Tem[0];
                
                reach = false;

            }


           
            if (transform.position != tilemap.CellToWorld(NextStep) && reach == false)
            {
                //transform.position = Vector3.Lerp(PlayerCenterPos, TargetMovement, Time.deltaTime * speed);
                transform.position = Vector3.MoveTowards(transform.position, tilemap.CellToWorld(NextStep), 1.3f*Time.deltaTime);

            }




            else
            {

                reach = true;

                Tem.RemoveAt(0);


            }

            EnemyMapPosition = tilemap.WorldToCell(transform.position);
        }
        else
        {
            //vectorint vector=position,if(vector==player.position){debug.log(trigger)}
            TurnFinished = true;
            PathFinished = true;
            NextTurn = false;
            OnlyOnce = false;
            CheckInRange = true;
            
        }
    }




    public List<Vector3Int> FindPlayer(int Radius,Vector3Int EnemyMapPosition)//this function is used to get all the positions with a certain radius
    {

        List<Vector3Int> PositionsInRange = new List<Vector3Int>();

        int DivisionNumDown = Radius / 2;
        int DivisionNumUp = Radius / 2;


        if (EnemyMapPosition.y % 2 == 0 || EnemyMapPosition.y == 0)//get all the positions in area
        {
            for (int y = -Radius; y <= 0; y++)
            {


                if (y % 2 == 0 || y == 0)
                {

                    for (int x = -(Radius - DivisionNumDown); x <= Radius - DivisionNumDown; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                             && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }
                    DivisionNumDown = DivisionNumDown - 1;
                }
                else
                {
                    for (int x = -(Radius - DivisionNumDown); x < Radius - DivisionNumDown; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                             && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }
                }
            }
            for (int y = Radius; y > 0; y--)
            {

                if (y % 2 == 0 || y == 0)
                {

                    for (int x = -(Radius - DivisionNumUp); x < Radius + DivisionNumUp - 1; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                             && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }
                    DivisionNumUp = DivisionNumUp - 1;
                }
                else
                {
                    for (int x = -(Radius - DivisionNumUp); x < Radius - DivisionNumUp; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                            && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }

                }
            }
        }
        else
        {
            for (int y = -Radius; y <= 0; y++)
            {

                //Debug.Log("division" + DivisionNumDown);
                if (y % 2 == 0 || y == 0)
                {
                    for (int x = -(Radius - DivisionNumDown); x <= Radius - DivisionNumDown; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                            && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }
                    DivisionNumDown = DivisionNumDown - 1;
                }
                else
                {

                    for (int x = -(Radius - DivisionNumDown) + 1; x <= Radius - DivisionNumDown; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                             && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }


                }
            }
            for (int y = Radius; y > 0; y--)
            {

                if (y % 2 == 0 || y == 0)
                {
                    for (int x = -(Radius - DivisionNumUp); x <= Radius - DivisionNumUp; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null
                            && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if (!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }


                        }
                    }
                    DivisionNumUp = DivisionNumUp - 1;
                }
                else
                {

                    for (int x = -(Radius - DivisionNumUp) + 1; x <= Radius - DivisionNumUp; x++)
                    {
                        if (tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != null 
                            && tilemap.GetTile(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)) != load.tiles[0])
                        {
                            if(!Physics2D.Linecast(transform.position, tilemap.CellToWorld(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z)), linemask))
                            {
                                PositionsInRange.Add(new Vector3Int(EnemyMapPosition.x + x, EnemyMapPosition.y + y, EnemyMapPosition.z));
                            }
                            

                        }
                            
                    }


                }
            }
        }
        
        foreach (Vector3Int vector in PositionsInRange)
        {
            if (tilemap.GetTile(vector) != null && tilemap.GetTile(vector) != load.tiles[0])
            {
                Vector3 CellWorldPosition = tilemap.CellToWorld(vector);
                //Debug.DrawLine(transform.position, CellWorldPosition, Color.black);

               


            }
            //else
            //{
            //    PositionsInRange.Remove(vector);
            //}

        }
        return PositionsInRange;
    }



    public void SetEnemyTurn()
    {
        NextTurn = true;
       
    }

    public bool GetTurnFinished()
    {
        return TurnFinished;
    }


    public void SetTurnFinished()
    {
        TurnFinished = false;
    }
}
