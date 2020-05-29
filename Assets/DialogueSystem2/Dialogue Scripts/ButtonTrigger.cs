using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Text text;
    public CurrentDialogue currentDialogue;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Dialogue Panel").Find("DialogueText").GetComponent<Text>();
        currentDialogue = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Dialogue Panel").GetComponent<CurrentDialogue>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickButton()
    {
        text.text = dialogue.dialogueText;
        currentDialogue.CleanDialoguePanel();
        currentDialogue.SetUpButtons(dialogue.NextID);
    }
}
