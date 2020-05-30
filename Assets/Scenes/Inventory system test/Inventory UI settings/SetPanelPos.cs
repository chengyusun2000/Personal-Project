using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanelPos : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField]private Transform InCanvasPos;
    [SerializeField] private Transform OutCanvasPos;
    [SerializeField] private bool InPos = false;
    [SerializeField] private bool OutPos = false;
    // Start is called before the first frame update
    void Start()
    {
         
        
        foreach (Transform transform in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {

            if (transform.tag == "InventoryPanel")
            {
                InventoryPanel = transform.gameObject;
            }
            else if(transform.tag== "InventoryPosition")
            {
                InCanvasPos = transform;
            }
            else if(transform.tag == "OutPosition")
            {
                OutCanvasPos = transform;
            }
            
        }
        
        SetOutPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInPosition()
    {
        InventoryPanel.transform.position = InCanvasPos.position;
        InPos = true;
        OutPos = false;
    }
    public void SetOutPosition()
    {
        InventoryPanel.transform.position = OutCanvasPos.position;
        InPos = false;
        OutPos = true;
    }
    public void SetPos()
    {
        if(InPos&&!OutPos)
        {
            SetOutPosition();
        }
        else
        {
            SetInPosition();
        }
    }
}
