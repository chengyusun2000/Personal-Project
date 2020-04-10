using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GetnodeData : MonoBehaviour
{
    public Tile[] tiles;
    public Tilemap tilemap;
    public Vector3Int vector;
    public int weigth = 10;
    public int length = 10;
    public List<node> nodes;
    public node CurrentNode;

    [Header("para for nodes")]
    Vector3Int position;
    string types;
    bool walk;
    float weight;

    enum TileType
    {
        water,
        grass,
        mountain
    }
    // Start is called before the first frame update
    void Start()
    {
        nodes = new List<node>();
        
        for (int x = 0; x < weigth; x++)
        {
            for (int y = 0; y < length; y++)
            {
                
                vector = new Vector3Int(x, y, 0);
                if( tilemap.GetTile(vector)==tiles[0])
                {
                    //CurrentNode = new node(vector, true, TileType.grass.ToString());
                    types = TileType.water.ToString();

                    walk = false;
                    weight = 9999;
                }
                else if (tilemap.GetTile(vector) == tiles[1])
                {
                    types = TileType.grass.ToString();

                    walk = true;
                    weight = 1;
                }
                else if (tilemap.GetTile(vector) == tiles[2])
                {
                    types = TileType.mountain.ToString();

                    walk = true;
                    weight = 1.2f;
                }
                else
                {
                    types = "null";
                    walk = false;
                    
                }
                position = vector;
                CurrentNode = new node(position, walk, types,weight);
                nodes.Add(CurrentNode);

            }
        }



        //for(int i=0;i<=nodes.Count-1;i++)
        //{
        //    Debug.Log(nodes[i].position[0]+ "," + nodes[i].position[1] + "," + nodes[i].position[2] + "  " + nodes[i].type + "  " + nodes[i].walkable);
        //}

        //vector = new Vector3Int(0 ,0 , 0);
        //Debug.Log("name : " + tilemap.GetTile(vector).name + " & position : " + vector);
        Save(nodes);
    }

    public static void Save( List<node> list)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "C:/Users/22167/Desktop/unity project/tank/project/Personal Project/Assets/script" + "/map_data";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, list);
        stream.Close();

    }
    public static void Load(List<node> list)
    {
        string path = "C:/Users/22167/Desktop/unity project/tank/project/Personal Project/Assets/script" + "/map_data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<node> nodes = formatter.Deserialize(stream) as List<node>;
            stream.Close();
        }
        else
        {
            Debug.LogError("File not found");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
