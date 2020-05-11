using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public List<Slots> Sslots;
    public Slots[,] slots;
    public Image Parent;
    public float x;
    public float y;
    public RectTransform RectTransform;
    public ItemObj food;
    public ItemObj Potion;
    public int Width=12;
    public int length = 8;
    [SerializeField] private bool PickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform = transform.GetComponent<RectTransform>();
        
        x = RectTransform.position.x - 520;
        y = RectTransform.position.y - 360;
        slots = new Slots[12, 8];
        
       
        for (int i = 0; i < 12; i++)
        {
            for (int o = 0; o < 8; o++)
            {
                slots[i, o] = new Slots(false/*, (x + 80 * (i + 1)), (y + 80 * (o + 1))*/);
                Sslots.Add(new Slots(false/*, (x + 80 * (i + 1)), (y + 80 * (o + 1)))*/));
                //Instantiate(test, new Vector3((x + 80 * (i + 1)), (y + 80 * (o + 1))), Quaternion.identity, Parent.transform);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        x = RectTransform.position.x - 520;
        y = RectTransform.position.y - 360;
    }
    
    public void PickUpObject(ItemObj item)
    {
        
        for (int i = 0; i < 12; i++)
        {
            for (int o = 0; o < 8; o++)
            {
                if(!PickedUp)
                {
                    if (!slots[i, o].Occupied)
                    {
                        AddItem(i, o, item);

                    }
                }
               
            }
        }
        if(!PickedUp)
        {
            Debug.Log("Inventory full");
        }
        PickedUp = false;


    }

    public void AddItem(int x,int y,ItemObj items)
    {
        if ((Width-x<items.width)||(length-y<items.height))
        {
            Debug.Log("oc");
            PickedUp = false;
            return;
        }
        else
        {

            for (int CheckX = x; CheckX < items.width+x; CheckX++)
            {
                for (int CheckY = y ; CheckY < items.height+y; CheckY++)
                {
                    if (slots[CheckX, CheckY].Occupied)
                    {
                        Debug.Log("occ");
                        return;
                    }
                    else
                    {
                        Debug.Log("yes");
                    }

                }
            }
            float FloatWidth = items.width;
            float FloatHeight = items.height;
            float PositionX;
            float PositionY;
            if (OddOrEven(items.width)==0)
            {
                 PositionX = (float)(RectTransform.position.x  - 520+80 + 80 * (FloatWidth / 4) + 80 * x);
            }
            else
            {
                PositionX = (float)(RectTransform.position.x- 520 +80+ 80 * ((FloatWidth-1) / 2) + 80 * x);
            }


            if(OddOrEven(items.height)==0)
            {
                 PositionY = (float)(RectTransform.position.y - 360+80 + 80 * (FloatHeight / 4) + 80 * y);
            }
            else
            {
                 PositionY = (float)(RectTransform.position.y - 360 + 80+80 * ((FloatHeight-1) / 2) + 80 * y);
            }

            
            
            Debug.Log("divide" + FloatWidth / 2);
            
            
            
            Instantiate(items.image, new Vector3(PositionX, PositionY, 0), Quaternion.identity, Parent.transform);
            PickedUp = true;
            Debug.Log(PositionX + " " + PositionY);
            for (int CheckX = x; CheckX < items.width + x; CheckX++)
            {
                for (int CheckY = y; CheckY < items.height + y; CheckY++)
                {
                    
                    slots[CheckX, CheckY].Occupied = true;
                    Debug.Log(CheckX + " " + CheckY + " " + slots[CheckX, CheckY].Occupied);

                }
            }
        }

    }
    public int OddOrEven(int Number)
    {
        if(Number%2==0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}
