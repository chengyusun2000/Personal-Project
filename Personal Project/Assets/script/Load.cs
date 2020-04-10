using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;
public class Load : MonoBehaviour
{
    public Tile[] tiles;
    public List<node> nodes;
    public Vector3Int insVector;
    public Tilemap tilemap;
    //public node currentNode;
    public int sizeOfMap;
    public List<node> TestNei;
    // Start is called before the first frame update
    
    void Start()
    {
        nodes = Loading();
        insVector = new Vector3Int(0, 0, 0);
        sizeOfMap = ((int)Mathf.Sqrt(nodes.Count + 1))-1;
        
        for (int i = 0; i < nodes.Count - 1; i++)
        {

            insVector = new Vector3Int(nodes[i].position[0], nodes[i].position[1], nodes[i].position[2]);

            //currentNode = new node(insVector, nodes[i].walkable, nodes[i].type);
            if (nodes[i].type == "water")
            {
                tilemap.SetTile(insVector, tiles[0]);
            }
            else if (nodes[i].type == "grass")
            {
                tilemap.SetTile(insVector, tiles[1]);
            }
            else if (nodes[i].type == "mountain")
            {
                tilemap.SetTile(insVector, tiles[2]);
            }


        }


    }

    // Update is called once per frame
    void Update()
    {

    }
    public static List<node> Loading()
    {
        string path = "C:/Users/22167/Desktop/unity project/tank/project/Personal Project/Assets/script" + "/map_data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<node> nodes = formatter.Deserialize(stream) as List<node>;
            stream.Close();
            return nodes;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }

    }
    public node GetStartNode(Vector3 player)
    {
        Vector3Int vector = tilemap.WorldToCell(player);
        node node;
        if (tilemap.GetTile(vector) == tiles[0])
        {

            node = new node(vector, false, "water",9999);
            return node;
        }
        else if (tilemap.GetTile(vector) == tiles[1])
        {

            node = new node(vector, true, "grass",1);
            return node;
        }
        else if (tilemap.GetTile(vector) == tiles[2])
        {

            node = new node(vector, true, "mountain", 1.2f);
            return node;
        }
        else
        {
            return null;
        }




    }
    public node GetEndNode(Vector3 target)
    {
        //Vector3Int vector = tilemap.WorldToCell(target);
        ////Debug.Log("vector"+target);
        //node node;
        //if (tilemap.GetTile(vector ) == tiles[0])
        //{

        //    node = new node(vector , false, "water");
        //    return node;
        //}
        //else if (tilemap.GetTile(vector ) == tiles[1])
        //{

        //    node = new node(vector, true, "grass");
        //    return node;
        //}
        //else
        //{
        //    return null;
        //}
        Vector3Int vector = tilemap.WorldToCell(target);
        Debug.Log("position" + vector);
        node node;
        if (tilemap.GetTile(vector) == tiles[0])
        {

            node = new node(vector, false, "water",9999);
            return node;
        }
        else if (tilemap.GetTile(vector) == tiles[1])
        {

            node = new node(vector, true, "grass",1);
            return node;
        }
        else if (tilemap.GetTile(vector) == tiles[2])
        {

            node = new node(vector, true, "mountain", 1.2f);
            return node;
        }
        else
        {
            return null;
        }
    }

    public List<node> NeighbourNodes(node OriginNode)
    {
        
        Vector3Int vector;
        List<node> NeighboursList = new List<node>();
        if(OriginNode.position[1]%2==0|| OriginNode.position[1]==0)
        {
            if (OriginNode.position[1] + 1 <= sizeOfMap&& OriginNode.position[0] -1 >=0 )
            {
                vector = new Vector3Int(OriginNode.position[0]-1, OriginNode.position[1] + 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));


                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }

                Debug.Log("even left up");
            }// even left up node
            if ( OriginNode.position[1] + 1 <= sizeOfMap)
            {
                vector = new Vector3Int(OriginNode.position[0], OriginNode.position[1] + 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("even right up");
            }//even right up node
            if (OriginNode.position[0] - 1 >= 0)
            {
                vector = new Vector3Int(OriginNode.position[0] - 1, OriginNode.position[1], OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("even left");
            }//even left node
            if (OriginNode.position[0] + 1 <= sizeOfMap)
            {
                vector = new Vector3Int(OriginNode.position[0] + 1, OriginNode.position[1], OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("even right");
            }//even right node
            if (OriginNode.position[1] - 1 >= 0&& OriginNode.position[0] - 1 >= 0)
            {
                vector = new Vector3Int(OriginNode.position[0]-1, OriginNode.position[1] - 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("even left down");
            }//even left down node
            if (OriginNode.position[1] - 1 >= 0 )
            {
                vector = new Vector3Int(OriginNode.position[0] , OriginNode.position[1] - 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("even right down");
            }//even right down node

        }//even
        else
        {
            if (OriginNode.position[1] + 1 <= sizeOfMap)
            {
                vector = new Vector3Int(OriginNode.position[0], OriginNode.position[1] + 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));


                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("odd left up");
            }//odd left up node
            if (OriginNode.position[0] + 1 <= sizeOfMap && OriginNode.position[1] + 1 <= sizeOfMap)
            {
                vector = new Vector3Int(OriginNode.position[0] + 1, OriginNode.position[1] + 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("odd right up");
            }//odd right up node
            if (OriginNode.position[0] - 1 >= 0)
            {
                vector = new Vector3Int(OriginNode.position[0] - 1, OriginNode.position[1], OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("odd left");
            }//odd left node
            if (OriginNode.position[0] + 1 <= sizeOfMap)
            {
                vector = new Vector3Int(OriginNode.position[0] + 1, OriginNode.position[1], OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("odd right");
            }//odd right node
            if (OriginNode.position[1] - 1 >= 0)
            {
                vector = new Vector3Int(OriginNode.position[0], OriginNode.position[1] - 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("odd left down");
            }//odd left down node
            if (OriginNode.position[1] - 1 >= 0 && OriginNode.position[0] + 1 <= sizeOfMap)
            {
                vector = new Vector3Int(OriginNode.position[0] + 1, OriginNode.position[1] - 1, OriginNode.position[2]);
                if (tilemap.GetTile(vector) == tiles[0])
                {

                    NeighboursList.Add(new node(vector, false, "water",9999));

                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    NeighboursList.Add(new node(vector, true, "grass",1));
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    NeighboursList.Add(new node(vector, true, "mountain", 1.2f));
                }
                Debug.Log("odd right down");
            }//odd right down node
            
            
        }//odd
        TestNei = NeighboursList;
        return NeighboursList;
    }

}
