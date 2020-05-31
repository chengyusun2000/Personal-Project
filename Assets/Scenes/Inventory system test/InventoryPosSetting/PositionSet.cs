using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSet : MonoBehaviour
{
    public RectTransform InPos;
    public RectTransform OutPos;
    public RectTransform Panel;
    [SerializeField] private bool InP = false;
    [SerializeField] private bool OutP = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform transform in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {
            
            if (transform.tag == "InventoryPanel")
            {
                Panel = transform.GetComponent<RectTransform>();
            }
            else if(transform.tag=="InPos")
            {
                InPos= transform.GetComponent<RectTransform>();
            }
            else if(transform.tag == "OutPos")
            {
                OutPos = transform.GetComponent<RectTransform>();
            }
            
        }
        SetOutPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInPos()
    {
        Panel.position = InPos.position;
        InP = true;
        OutP = false;
    }

    public void SetOutPos()
    {
        Panel.position = OutPos.position;
        InP = false;
        OutP = true;
    }

    public void SetPosition()
    {
        if(InP==true&&OutP==false)
        {
            SetOutPos();
        }
        else if(InP == false && OutP == true)
        {
            SetInPos();
        }
    }
}
