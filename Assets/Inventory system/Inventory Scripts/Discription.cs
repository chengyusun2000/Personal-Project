using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Discription : MonoBehaviour
{
    private ItemObj item;
    private Text NameText;
    private Text TypeText;
    private Text DiscriptionText;
   
    // Start is called before the first frame update
    void Start()
    {
        NameText = transform.Find("Name").GetComponent<Text>();
        TypeText = transform.Find("Type").GetComponent<Text>();
        DiscriptionText = transform.Find("Discription").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        NameText.text = item.name;
        TypeText.text = item.type.ToString();
        DiscriptionText.text = item.discription;
    }

    public void SetItem(ItemObj itemObj)
    {
        item = itemObj;
    }
}
