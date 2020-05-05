using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Prefab.Length);
        Instantiate(Prefab[Random.Range(0,Prefab.Length)], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
