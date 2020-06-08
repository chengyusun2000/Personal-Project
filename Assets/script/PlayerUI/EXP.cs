using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    public Text expText;
    public int level = 0;

    public Slider expAmount;
    private EXP exp;

    // Start is called before the first frame update
    void Start()
    {
        exp = GetComponent<EXP>();
        expAmount.value = 0;
        expText.text = "EXP: Lv." + level.ToString("D1");   // Question: like the question in HP
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void SetMaxExp(int Exp)
    //{
    //    expAmount.maxValue = Exp;
    //    expAmount.value = Exp;
    //}

    public void GetExp()
    {
        //expAmount.value = Exp;
        if (expAmount.value == 10)
        {
            level++;
            expAmount.value = 0;
        }
        expText.text = "EXP: Lv." + level.ToString("D1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            Debug.Log("Exp" + other.name);
            expAmount.value = 10;
            GetExp();
        }
    }
}
