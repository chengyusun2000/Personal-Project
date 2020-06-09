using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public MonsterRecord monsterRecord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SlaySlime()
    {
        monsterRecord.AddAmount(MonsterType.Slime);
    }
}
