using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
     [SerializeField]private int HP;
     private int Mana;
     private int Stamina;
     private int MaxHP;
     private int MaxMana;
     private int MaxStamina;
     private int Damage;
    // Start is called before the first frame update
    void Awake()
    {
        MaxHP = 100;
        MaxMana = 100;
        MaxStamina = 100;
        Stamina = 100;
}

    // Update is called once per frame
    void Update()
    {
        
    }


    public int GetHp()
    {
        return HP;
    }
    public int GetMana()
    {
        return Mana;
    }
    public int GetStamina()
    {
        return Stamina;
    }


    public void AddHp(int amount)
    {
        HP = HP + amount;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        else if (HP <= 0)
        {
            HP = 0;
        }
    }
    public void AddMana(int amount)
    {
        Mana = Mana + amount;
        if(Mana>MaxMana)
        {
            Mana = MaxMana;
        }
    }
    public void AddStanima(int amount)
    {
        Stamina = Stamina + amount;
        if(Stamina>MaxStamina)
        {
            Stamina = MaxStamina;
        }
    }
    public void AddDamage(int amount)
    {
        Damage = Damage + amount;
    }


    public int GetMaxHp()
    {
        return MaxHP;
    }
    public int GetMaxMana()
    {
        return MaxMana;
    }
    public int GetMaxStamina()
    {
        return MaxStamina;
    }
    public int GetDamage()
    {
        return Damage;
    }

    public void AddMaxHp(int amount)
    {
        MaxHP = MaxHP + amount;
        
    }
    public void AddMaxMana(int amount)
    {
        MaxMana = MaxMana + amount;
        
    }
    public void AddMaxStanima(int amount)
    {
        MaxStamina = MaxStamina + amount;
        
    }
    
}
