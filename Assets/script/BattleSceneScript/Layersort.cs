using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layersort : MonoBehaviour
{
    private int TotalLayers = 10000;
    [SerializeField]private int offset;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {

        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sortingOrder = (int)(TotalLayers - transform.position.y - offset);
    }
}
