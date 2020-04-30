using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ins : MonoBehaviour
{
    public Tile pre;
    public Tilemap tilemap;
    public Vector3Int vector;
    public int weigth = 10;
    public int length = 10;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3Int vector = tilemap.WorldToCell(player.position);
        tilemap.SetTile(vector, pre);
        //for(int x=0;x<=weigth;x++)
        //{
        //    for(int y=0; y<=length;y++)
        //    {
        //        vector = new Vector3Int(x, y, 0);
        //        tilemap.SetTile(vector, pre);
        //        Debug.Log("name : " + tilemap.GetTile(vector).name + " & position : " + vector);
        //    }
        //}


        //tilemap.SetTile(vector, pre);





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
