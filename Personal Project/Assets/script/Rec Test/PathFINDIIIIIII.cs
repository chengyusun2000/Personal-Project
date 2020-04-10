using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PathFINDIIIIIII : MonoBehaviour
{

    
    public List<Node> PathTest;
    public Transform player;

    public Transform target;

    public Node Test;
    public Node newnode;
    public int testnumber;
    public List<Node> testlist;
    public List<Node> openset;

    public List<Node> Closed;
    public Tilemap tilemap;
    public List<Node> path;
    //List<node> openset = new List<node>();
    //HashSet<node> Closed = new HashSet<node>();

    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Target").transform;
       
        FinDAPath(player.position, target.position);
        //for(int i=0;i<path.Count;i++)
        //{
        //    Debug.Log(path[i].position[0] + " " + path[i].position[1] + " " + path[i].position[2]);
        //}

    }

    void Update()
    {

        //Test = load.GetStartNode(PlayerMapPosition);


        //for (int i = 0; i < Path.Count - 1; i++)
        //{




        //}
    }
    public void FinDAPath(Vector3 StartPoint, Vector3 EndPoint)
    {


        Node StartNode = GetStartnode(StartPoint);
        Node EndNode = GetEndnode(EndPoint);
        StartNode.Gcost = 0;
        StartNode.Hcost = GetDistance(StartNode,EndNode);
        openset = new List<Node>();
        Closed = new List<Node>();

        openset.Add(StartNode);

        while (openset.Count > 0)
        {
            Node currentNode = openset[0];
            for (int i = 1; i < openset.Count; i++)
            {
                
                    

                if (openset[i].Fcost < currentNode.Fcost)
                {

                    currentNode = openset[i];





                }
            }



            if (currentNode == EndNode)
            {
                retracePath(StartNode, EndNode);
                return;
            }
            openset.Remove(currentNode);
            Debug.Log("count" + openset.Count);
            Closed.Add(currentNode);



            foreach (Node neighbour in getneighbour(currentNode))
            {

                if (!neighbour.walkable || Closed.Contains(neighbour))
                {
                    continue;
                }
                int MovementcostToNewNeighbour = currentNode.Gcost + GetDistance(currentNode, neighbour);
                Debug.Log("number" + MovementcostToNewNeighbour);
                if (MovementcostToNewNeighbour < neighbour.Gcost || !Closed.Contains(neighbour))
                {
                    neighbour.parent = currentNode;
                    neighbour.Gcost = MovementcostToNewNeighbour;
                    neighbour.Hcost = GetDistance(neighbour, EndNode);
                    

                    if (!openset.Contains(neighbour))
                    {
                        //Test = neighbour;
                        //openset.Add(neighbour);

                    }
                    



                }

            }

        }

    }
    public void retracePath(Node StartNode, Node EndNode)
    {
         path = new List<Node>();
        Node currentnode = EndNode;
        while (currentnode != StartNode)
        {
            path.Add(currentnode);
            currentnode = currentnode.parent;
        }
        path.Reverse();
       
    }
    int GetDistance(Node A, Node B)
    {
        //Debug.Log(A.position[0] + " " + A.position[1] + " " + A.position[2] /*+ "     " + B.position[0] + B.position[1] + B.position[2]*/ );
        int distanceX = Mathf.Abs(A.position[0] - B.position[0]);
        int distanceY = Mathf.Abs(A.position[1] - B.position[1]);

        return distanceX + distanceY;





    }



    public Node GetStartnode(Vector3 player)
    {
        Vector3Int vector = tilemap.WorldToCell(player);
        Node node = new Node(vector, true);
        return node;
    }
    public Node GetEndnode(Vector3 Target)
    {
        Vector3Int vector = tilemap.WorldToCell(Target);
        Node node = new Node(vector, true);
        return node;
    }
    public List<Node> getneighbour(Node origin)
    {
        Debug.Log("origin" + origin.position[0] + origin.position[1] + origin.position[2]);
        Vector3Int vector;
        List<Node> neighbour = new List<Node>();
        if (origin.position[0]-1>=0)
        {
            vector = new Vector3Int(origin.position[0]-1, origin.position[1], origin.position[2]);
            neighbour.Add(new Node(vector, true));

        }//left

        if (origin.position[0] + 1 <=5 )
        {
            vector = new Vector3Int(origin.position[0]+1, origin.position[1], origin.position[2]);
            neighbour.Add(new Node(vector, true));

        }//RIGHT
        if (origin.position[1]-  1 >= 0)
        {
            vector = new Vector3Int(origin.position[0], origin.position[1]-1, origin.position[2]);
            neighbour.Add(new Node(vector, true));

        }//up

        if (origin.position[1] + 1 <= 5)
        {
            vector = new Vector3Int(origin.position[0], origin.position[1]+1, origin.position[2]);
            neighbour.Add(new Node(vector, true));

        }//down
        testlist = neighbour;
        return neighbour;
    }
}
