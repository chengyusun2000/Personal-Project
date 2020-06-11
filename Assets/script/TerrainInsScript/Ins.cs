using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefab;
    bool onlyonce = false;
    public TestScene testScene;
    // Start is called before the first frame update
    void Start()
    {
        testScene = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TestScene>();
        Debug.Log(Prefab.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(testScene.Done&&!onlyonce)
        {
            Instantiate(Prefab[Random.Range(0, Prefab.Length)], transform.position, Quaternion.identity);
            onlyonce = true;
        }
    }
}
