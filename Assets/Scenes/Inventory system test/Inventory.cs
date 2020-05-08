using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public List<Slots> Sslots;
    public Slots[,] slots;
    public Image test;
    public Image test1;
    public Image Parent;
    public float x;
    public float y;
    public Food food;
    public int Width=12;
    public int length = 8;
    // Start is called before the first frame update
    void Start()
    {
        slots = new Slots[12, 8];
        x = transform.position.x - 520;
        y = transform.position.y - 360;
       
        for (int i = 0; i < 12; i++)
        {
            for (int o = 0; o < 8; o++)
            {
                slots[i, o] = new Slots(false, (x + 80 * (i + 1)), (y + 80 * (o + 1)));
                Sslots.Add(new Slots(false, (x + 80 * (i + 1)), (y + 80 * (o + 1))));
                Instantiate(test, new Vector3((x + 80 * (i + 1)), (y + 80 * (o + 1))), Quaternion.identity, Parent.transform);
            }
        }
        AddI(2, 2, food);
        //AddItem(x + 160, y + 160, food);
        //AddItem(x + 160, y + 160, food);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void AddI(int x,int y,Items items)
    {

        if ((x == 0 || y == 0) && (items.height > 1 || items.width > 1))
        {
            Debug.Log("oc");
            return;
        }
        else
        {

            for (int CheckX = x - items.height / 2; CheckX <= x + items.height / 2; CheckX++)
            {
                for (int CheckY = y - items.width / 2; CheckY <= y + items.width / 2; CheckY++)
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
            float PositionX = (float)(69.19995 + 80 * x);
            float PositionY = (float)(262.7 + 80 * y);
            Instantiate(items.Image, new Vector3(PositionX, PositionY, 0), Quaternion.identity, Parent.transform);

            for (int CheckX = x - items.height / 2; CheckX<= x + items.height / 2; CheckX++)
            {
                for (int CheckY = y - items.width / 2; CheckY <= y + items.width / 2; CheckY++)
                {
                    Debug.Log(CheckX + " " + CheckY);
                    slots[CheckX, CheckY].Occupied = true;

                }
            }
        }
    }


    public void AddItem(float x,float y,Items items)
    {
        Debug.Log(x);
        Debug.Log(x - 80 * (items.width / 2));
        Debug.Log(80 * (items.width / 2) + x);
        for(float CheckX=(x-80*(items.width/2));CheckX<=80* (items.width / 2) + x;CheckX=CheckX+80)
        {
            for (float CheckY = (y - 80 * (items.height / 2)); CheckY <= 80 * (items.height/2)+y; CheckY = CheckY + 80)
            {
                int i=((int)(CheckX-69.19995)/80);
                int o= ((int)(CheckY - 262.7) / 80);
                Debug.Log(i+","+o);
                if (slots[i, o].Occupied)
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
        Instantiate(items.Image, new Vector3(x, y, 0), Quaternion.identity, Parent.transform);
        for (float CheckX = (x - 80 * (items.width / 2)); CheckX <= 80 * (items.width / 2) + x; CheckX = CheckX + 80)
        {
            for (float CheckY = (y - 80 * (items.height / 2)); CheckY <= 80 * (items.height / 2) + y; CheckY = CheckY + 80)
            {
                int i = ((int)(CheckX - 69.19995) / 80);
                int o = ((int)(CheckY - 262.7) / 80);
                Debug.Log(i + "," + o);
                slots[i, o].Occupied = true;

            }
        }

    }
}
