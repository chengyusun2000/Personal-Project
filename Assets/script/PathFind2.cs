using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind2 : MonoBehaviour
{
    public Transform seeker, target;
    Load load;
    public List<node> Test;

    void Awake()
    {
        load = GetComponent<Load>();
    }

    void Update()
    {
        FindPath(seeker.position, target.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        node StartNode = load.GetStartNode(startPos);

        node EndNode = load.GetEndNode(targetPos);
        List<node> openset = new List<node>();
        HashSet<node> Closed = new HashSet<node>();
       openset.Add(StartNode);

        while (openset.Count > 0)
        {
            node node = openset[0];
            for (int i = 1; i < openset.Count; i++)
            {
                if (openset[i].Fcost < node.Fcost || openset[i].Fcost == node.Fcost)
                {
                    if (openset[i].Hcost< node.Hcost)
                        node = openset[i];
                }
            }

            openset.Remove(node);
            Closed.Add(node);

            if (node == EndNode)
            {
                RetracePath(StartNode, EndNode);
                return;
            }

            foreach (node neighbour in load.NeighbourNodes(node))
            {
                if (!neighbour.walkable || Closed.Contains(neighbour))
                {
                    continue;
                }

                int newCostToNeighbour = node.Gcost + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.Gcost  || !openset.Contains(neighbour))
                {
                    neighbour.Gcost = newCostToNeighbour;
                    neighbour.Hcost = GetDistance(neighbour, EndNode);
                    neighbour.parent = node;

                    if (!openset.Contains(neighbour))
                    {

                    }
                    openset.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(node startNode, node endNode)
    {
        Test = new List<node>();
        node currentNode = endNode;

        while (currentNode != startNode)
        {
            Test.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Test.Reverse();

        

    }

    int GetDistance(node nodeA, node nodeB)
    {
        int distanceX = Mathf.Abs(nodeA.position[0] - nodeB.position[0]);
        int distanceY = Mathf.Abs(nodeA.position[1] - nodeB.position[1]);
        
            return distanceX * distanceX + distanceY * distanceY;
        
        
    }
}
