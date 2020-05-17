using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsList : MonoBehaviour
{
    [SerializeField] private List<QuestBase> questBases;
    // Start is called before the first frame update
    void Start()
    {
        QuestBase FIRST = questBases[0];
        Debug.Log(FIRST.FindFirstEvent().Index);
        foreach(QuestEventBase questEventBase in FIRST.NextEvent(FIRST.FindFirstEvent()))
        {
            Debug.Log(questEventBase.Discription);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
