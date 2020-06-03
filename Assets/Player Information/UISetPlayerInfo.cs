using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISetPlayerInfo : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Slider HP;
    [SerializeField] private Slider Mana;
    [SerializeField] private Slider Stamina;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameData").GetComponent<PlayerInfo>();
        foreach(Slider slider in gameObject.GetComponentsInChildren<Slider>())
        {
            if(slider.name=="HealthBar")
            {
                HP = slider;
            }
            else if(slider.name=="ManaBar")
            {
                Mana = slider;
            }
            else if(slider.name=="StaminaBar")
            {
                Stamina = slider;
            }
            
        }

        playerInfo.AddHp(100);
        HP.maxValue = playerInfo.GetMaxHp();
        HP.value = playerInfo.GetHp();
        Mana.maxValue = playerInfo.GetMaxMana();
        Mana.value = playerInfo.GetMana();
        Stamina.maxValue = playerInfo.GetMaxStamina();
        Stamina.value = playerInfo.GetStamina();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
