using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSet : MonoBehaviour
{
    [SerializeField] private RectTransform InPos;
    [SerializeField] private RectTransform OutPos;
    [SerializeField] private RectTransform Panel;
    [SerializeField] private string PanelTag;
    [SerializeField] private string InTag;
    [SerializeField] private string OutlTag;
    private bool InP = false;
    private bool OutP = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform transform in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {
            
            if (transform.tag == PanelTag)
            {
                Panel = transform.GetComponent<RectTransform>();
            }
            else if(transform.tag==InTag)
            {
                InPos= transform.GetComponent<RectTransform>();
            }
            else if(transform.tag == OutlTag)
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
