using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentDialogue : MonoBehaviour
{
    public DialogueCombinationBase Current;
    [SerializeField] private Transform Parent;
    [SerializeField] Text DialogueText;
    public Button button;
    public Button temp;
    public List<Button> TempButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialogue()
    {
        DialogueText.text = Current.StartText;
        SetUpButtons(-1);
    }
    public List<Dialogue> FindChoices(int index)
    {
        
        List<Dialogue> Temp = new List<Dialogue>();
        foreach(Dialogue dialogue in Current.dialogues)
        {
            if(dialogue!=null)
            {
                if (dialogue.PreviousID == index)
                {
                    Temp.Add(dialogue);
                }
            }
            
            
        }
        return Temp;
    }
    public void SetUpButtons(int index)
    {
        foreach(Dialogue dialogue in FindChoices(index))
        {
            temp = Instantiate(button, Parent);
            temp.GetComponentInChildren<Text>().text = dialogue.ButtonText;
            temp.GetComponent<ButtonTrigger>().dialogue = dialogue;
            TempButtons.Add(temp);
        }
    }
    public void CleanDialoguePanel()
    {
        for(int i=TempButtons.Count;i>0;i--)
        {
            Destroy(TempButtons[0].gameObject);
            TempButtons.RemoveAt(0);
        }
    }
    public Dialogue FindPreviousDialogue(int index)
    {
        List< Dialogue> temp=new List<Dialogue>();
        foreach (Dialogue dialogue in Current.dialogues)
        {
            if (dialogue != null)
            {
                if (dialogue.NextID == index)
                {

                    temp.Add(dialogue);
                }
            }

            
        }
        return temp[0];
    }
}
