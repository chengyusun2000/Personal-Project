using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public LayerMask rayMask;
    public RaycastHit2D Hit2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right);
        Hit2D= Physics2D.Raycast(transform.position, transform.right, rayMask);
        if(Hit2D.transform.tag=="Box")
        {

        }
    }
}
