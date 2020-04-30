using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFind : MonoBehaviour
{
    public Load load;
    public List<node> PathTest;
    public Transform player;
    
    public Transform target;
    
    public node Test;

    public List<node> PathFound;



    // Start is called before the first frame update
    void Start()
    {
        PathFound = PathFinding(player.position, target.position);
    }

    public List<node> PathFinding(Vector3 StartPos,Vector3 TargetPos)
    {
        node StartNode = load.GetStartNode(StartPos);
        node TargetNode = load.GetEndNode(TargetPos);
        Debug.Log("gcost" + StartNode.Gcost);
        StartNode.Gcost = 0;
        StartNode.Hcost = GetDistance(StartNode, TargetNode);

        List<node> Open = new List<node>();
        List<node> Close = new List<node>();
        Open.Add(StartNode);
        List<node> Path = new List<node>();
        

        while(Open.Count>0)
        {
            
            node Current = Open[0];
            
            for (int i=1;i<Open.Count;i++)
            {
                if(Current.Fcost>Open[i].Fcost)
                {
                    Current = Open[i];
                }

                if(Current==TargetNode)
                {
                    Path.Reverse();
                    return Path;
                }

                Close.Add(Current);
                Open.Remove(Current);

                List<node> neighbourList = load.NeighbourNodes(Current);
                foreach(node neighbour in neighbourList)
                {

                    if(!neighbour.walkable || Close.Contains(neighbour))
                    {
                        continue;
                    }
                    int tentative_Gcost = Current.Gcost + GetDistance(Current, neighbour);

                    if(tentative_Gcost<neighbour.Gcost||!Close.Contains(neighbour))
                    {
                        Path.Add(Current);
                        neighbour.Gcost = tentative_Gcost;
                        neighbour.Hcost = GetDistance(neighbour, TargetNode);
                        if(!Open.Contains(neighbour))
                        {
                            //Open.Add(neighbour);
                        }
                    }
                }
            }
            
        }
        return null;

    }



    public int GetDistance(node A,node B)
    {
        int DisX = Mathf.Abs(A.position[0] - B.position[0]);
        int DisY = Mathf.Abs(A.position[1] - B.position[1]);
        //if(Mathf.Sign(DisX)==Mathf.Sign(DisY))
        //{
        //    return DisX + DisY;

        //}
        //else
        //{
        //    return Mathf.Max(DisY, DisX);
        //}
        return DisX + DisY;
    }

    
    


}
