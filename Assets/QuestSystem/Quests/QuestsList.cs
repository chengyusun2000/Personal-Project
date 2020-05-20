using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsList : MonoBehaviour
{
    [SerializeField] private List<QuestBase> questBases;
    [SerializeField] List<QuestEventBase> CurrentEvents;
    // Start is called before the first frame update
    void Start()
    {
        QuestBase FIRST = questBases[0];
        
        CurrentEvents = FIRST.GetCurrentEvent( FIRST.FindFirstEvent());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
