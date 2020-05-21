using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentQuests : MonoBehaviour
{
    [SerializeField] private List<QuestBase> Current;
    [SerializeField] private List<QuestBase> Finished;
    [SerializeField] private List<QuestEventBase> CurrentEvents;
    [SerializeField] private Button button;
    [SerializeField] private QuestsList questsList;
    
    public Transform QuestList;
    // Start is called before the first frame update
    void Start()
    {
        AddQuest(questsList.GetQuestBases()[0]);
        AddQuest(questsList.GetQuestBases()[0]);
        AddQuestToQuestList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddQuest(QuestBase NewQuest)
    {
        Current.Add(NewQuest);
    }
    public void MoveQuestToFinishend(QuestBase FinishedQuest)
    {
        Current.Remove(FinishedQuest);
        Finished.Add(FinishedQuest);
    }
    public void AddQuestToQuestList()
    {
        Button TempButton;
        GetDiscription getDiscription;
        foreach (QuestBase questBase in Current)
        {
            TempButton = Instantiate(button, QuestList);
            TempButton.transform.GetChild(0).GetComponent<Text>().text = questBase.QuestName;
            getDiscription = TempButton.transform.GetComponent<GetDiscription>();
            getDiscription.GetQuest(questBase);
        }
    }
}
