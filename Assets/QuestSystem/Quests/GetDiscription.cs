using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetDiscription : MonoBehaviour
{
    [SerializeField]private QuestBase Quest;
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("DontDestroyCanvas").transform.Find("Quests").Find("Discription").Find("Viewport").Find("Content").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisPlayDiscription()
    {
        text.text = Quest.GetCurrentEvent(Quest.FindFirstEvent())[0].Discription;
    }
    public void SetQuest(QuestBase quest)
    {
        Quest = quest;
    }

    public QuestBase GetQuest()
    {
        return Quest;
    }

    public Text GetText()
    {
        return text;
    }
}
