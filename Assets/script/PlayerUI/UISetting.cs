using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField]private PlayerInfo playerInfo;

    [Header("HP")]
    [SerializeField] private Slider hpAmount;

    [Header("MANA")]
    [SerializeField] private Slider manaAmount;

    [Header("EXP")]
    [SerializeField] private Slider expAmount;
    [SerializeField] private Text expText;
    [SerializeField] private int level = 0;

    [Header("STAMINA(FOOD)")]
    [SerializeField] private Slider foodAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameData").GetComponent<PlayerInfo>();

        hpAmount.maxValue = playerInfo.GetMaxHp();
        hpAmount.value = playerInfo.GetHp();

        manaAmount.maxValue = playerInfo.GetMaxMana();
        manaAmount.value = playerInfo.GetMana();

        expAmount.maxValue = 10;
        expAmount.value = 0;
        expText.text = "EXP: Lv." + level.ToString("D1");

        foodAmount.maxValue = playerInfo.GetMaxStamina();
        foodAmount.value = playerInfo.GetStamina();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetExp()
    {
        //expAmount.value = Exp;
        if (expAmount.value >= 10)
        {
            level++;
            expAmount.value = expAmount.value -= 10;
        }
        expText.text = "EXP: Lv." + level.ToString("D1");
    }

    private void OnTriggerEnter2D(Collider2D other) //Test
    {
        if (other.CompareTag("HpTest"))
        {
            Debug.Log("Hp" + other.name);
            hpAmount.value -= 5;
        }

        if (other.CompareTag("ManaTest"))
        {
            Debug.Log("MANA" + other.name);
            manaAmount.value += 2;
        }

        if (other.CompareTag("ExpTest"))
        {
            Debug.Log("Exp" + other.name);
            expAmount.value += 13;
            GetExp();
        }

        if (other.CompareTag("FoodTest"))
        {
            Debug.Log("Stamina" + other.name);
            foodAmount.value += 8;
        }
    }
}
