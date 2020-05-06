using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class EnemyEncounter : MonoBehaviour
{
    private string encounterScene;
    private int RandomEncounter;
    private string encounterTerrain;
    private Vector3Int playerPos;
    [SerializeField]private Tilemap tilemap;
    [SerializeField]private Tile[] tiles;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            RandomEncounter = Random.Range(1, 3);
           
            Debug.Log("trigger");
            playerPos = collision.GetComponent<playerMovement>().playerMapPosition;
            encounterTerrain = CheckPlayerPos();
            encounterScene = encounterTerrain + RandomEncounter.ToString();


           SceneManager.LoadScene(encounterScene);
        }
    }

    private string CheckPlayerPos()
    {
        string encounter = "1";
         if (tilemap.GetTile(playerPos) == tiles[0])
        {
            Debug.Log("Encounter Water");
            encounter= "WaterEncounter";
        }
        else if (tilemap.GetTile(playerPos) == tiles[1])
        {
            Debug.Log("Encounter Grass");
            encounter = "GrassEncounter";
        }
        else if (tilemap.GetTile(playerPos) == tiles[2])
        {
            Debug.Log("Encounter Mountain");
            encounter = "MountainEncounter";
        }
        return encounter;
    }
}
