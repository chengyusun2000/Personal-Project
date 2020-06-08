using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RightClickSet : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    bool InPanel = false;
    
    


    public void OnPointerEnter(PointerEventData eventData)
    {
        InPanel = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InPanel = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(!InPanel)
        {
            if(Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
        }
    }
}
