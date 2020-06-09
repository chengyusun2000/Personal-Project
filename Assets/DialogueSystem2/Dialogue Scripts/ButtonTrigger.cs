using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private Interaction interaction;
    [SerializeField] private CurrentQuests currentQuests;
    public Dialogue dialogue;
    public Text text;
    public CurrentDialogue currentDialogue;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Dialogue Panel").Find("DialogueText").GetComponent<Text>();
        currentDialogue = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Dialogue Panel").GetComponent<CurrentDialogue>();
        interaction = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Interaction>();
        currentQuests = GameObject.FindGameObjectWithTag("GameData").GetComponent<CurrentQuests>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickButton()
    {
        if(dialogue.Dtype==Dialogue.DialogueType.normal)
        {
            MoveToNextDialogue();
        }
        else if(dialogue.Dtype == Dialogue.DialogueType.Quit)
        {
            interaction.QuitPanel();
        }
        else if(dialogue.Dtype == Dialogue.DialogueType.Quest)
        {
            if(dialogue.quest!=null)
            {
                currentQuests.AddQuest(dialogue.quest.quest);
                currentDialogue.Current.dialogues.Remove(currentDialogue.FindPreviousDialogue(dialogue.PreviousID));
            }
            
           
            MoveToNextDialogue();
        }
        
    }
    public void MoveToNextDialogue()
    {
        
        text.text = dialogue.dialogueText;
        currentDialogue.CleanDialoguePanel();
        currentDialogue.SetUpButtons(dialogue.NextID);
    }
}
