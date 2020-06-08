using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider hpAmount;

    // Start is called before the first frame update
    void Start()
    {
        //hp = GetComponent<HP>();
        hpAmount.maxValue = 10; //Give a maxhp for the beginning. 
                                //Question: should increase the top maxhp when level +1?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetMaxHp(int Hp)
    //{
    //    hpAmount.maxValue = Hp;
    //    hpAmount.value = Hp;
    //}

    //public void GetOrLoseHp(int Hp)
    //{
    //    hpAmount.value = Hp;
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            Debug.Log("Hp" + other.name);
            hpAmount.value -= 5;
        }
    }
}
