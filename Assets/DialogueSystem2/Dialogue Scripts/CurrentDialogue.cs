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
        SetUpButtons();
    }
    public List<Dialogue> FindFirstChoices()
    {
        int index = -1;
        List<Dialogue> Temp = new List<Dialogue>();
        foreach(Dialogue dialogue in Current.dialogues)
        {
            if(dialogue.PreviousID==index)
            {
                Temp.Add(dialogue);
            }
            
        }
        return Temp;
    }
    public void SetUpButtons()
    {
        foreach(Dialogue dialogue in FindFirstChoices())
        {
            temp = Instantiate(button, Parent);
            temp.GetComponentInChildren<Text>().text = dialogue.ButtonText;
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
}
