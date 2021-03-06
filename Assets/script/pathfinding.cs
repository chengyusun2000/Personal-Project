﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
public class pathfinding : MonoBehaviour
{
    public Load load;
    
    public playerMovement playerMovement;
    public bool end = false;
    

    // Start is called before the first frame update
    void Start()
    {
        load = GetComponent<Load>();
       
        playerMovement = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerMovement>();



    }

    void Update()
    {
        
    }
    public List<node> FinDAPath(Vector3 StartPoint, Vector3 EndPoint)//a* pathfinding algrithm
    {
        node StartNode = load.GetStartNode(StartPoint);
        
        node EndNode = load.GetEndNode(EndPoint);
        StartNode.Gcost = 0;
        StartNode.Hcost = GetDistance(StartNode, EndNode);
        StartNode.weight = 1;
        List<node> openset = new List<node>();
        HashSet<node> Closed = new HashSet<node>();
        
        openset.Add(StartNode);
        
        while (openset.Count >0)
        {
            node currentNode = openset[0];
           
            for (int i = 1; i <openset.Count; i++)
            {
                
                    if (openset[i].Fcost < currentNode.Fcost)
                    {

                        currentNode = openset[i];

                        



                    }
                    else if (openset[i].Fcost == currentNode.Fcost)
                    {
                    if(openset[i].Hcost < currentNode.Hcost)
                    {
                        currentNode = openset[i];
                    }
                    }


            }
                
                    
                
            
            
            
            
            if ((currentNode.position[0] == EndNode.position[0])&& currentNode.position[1] == EndNode.position[1]&& currentNode.position[2] == EndNode.position[2])
            {



                //Debug.Log("final node" + currentNode.position[0] + " " + currentNode.position[1] + " " + currentNode.position[2] + currentNode.Gcost+"PARENT"+currentNode.parent.position[0]+"" + currentNode.parent.position[1] + ""  + currentNode.parent.position[2] + "" + currentNode.parent.Gcost);
                //Debug.Log("parent parent" + currentNode.parent.parent.position[0] + "" + currentNode.parent.parent.position[1] + "" + currentNode.parent.parent.position[2] + "" + currentNode.parent.parent.Gcost);
                //Debug.Log("parent parent parent" + currentNode.parent.parent.parent.position[0] + "" + currentNode.parent.parent.parent.position[1] + "" + currentNode.parent.parent.parent.position[2] + "" + currentNode.parent.parent.parent.Gcost);
                

                return retracePath(StartNode, currentNode);

                



            }
            
            openset.Remove(currentNode);
            Debug.Log("count" + openset.Count);
            Closed.Add(currentNode);


           
            foreach (node neighbour in load.NeighbourNodes(currentNode))
            {

                if (!neighbour.walkable || Closed.Contains(neighbour))
                {
                    continue;
                }
                int MovementcostToNewNeighbour = currentNode.Gcost + GetDistance(currentNode, neighbour);
                
                if (MovementcostToNewNeighbour < neighbour.Gcost || !Closed.Contains(neighbour))
                {
                    
                    neighbour.Gcost = MovementcostToNewNeighbour;
                    neighbour.Hcost = GetDistance(neighbour, EndNode);
                    neighbour.parent = currentNode;
                    
                    if (!openset.Contains(neighbour))
                    {
                        
                        openset.Add(neighbour);

                    }
                    //else
                    //{
                    //    continue;
                    //}



                }

            }

        }

       
            return null;
        
    }
    public List<node> retracePath(node StartNode, node currentNode)
    {
         List<node> PathTest = new List<node>();
        node PathFindNode = currentNode;
        while (!(currentNode.position[0] == StartNode.position[0]) || !(currentNode.position[1] == StartNode.position[1]))
        {
            PathTest.Add(currentNode);
            currentNode = currentNode.parent;

        }
        PathTest.Reverse();
        return PathTest;
    }
    int GetDistance(node A, node B)
    {
        //Debug.Log(A.position[0] + " " + A.position[1] + " " + A.position[2] /*+ "     " + B.position[0] + B.position[1] + B.position[2]*/ );
        int distanceX = Mathf.Abs(A.position[0] - B.position[0]);
        int distanceY = Mathf.Abs(A.position[1] - B.position[1]);


        return distanceX * distanceX + distanceY * distanceY;


    }
}
