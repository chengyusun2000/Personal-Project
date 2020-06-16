using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interaction : MonoBehaviour
{
    public LayerMask rayMask;

    [SerializeField] private PlayerMove PlayerMove;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Vector2 Movement;
    [SerializeField] private Text InteractText;
    [SerializeField] private Inventory inventory;
    [SerializeField] private CurrentDialogue currentDialogue;
    [SerializeField] private GameObject DialoguePanel;
    private RaycastHit2D Hit2D;


    [SerializeField] private bool StartCalculating = false;
    [SerializeField] private Transform NpcTransform;
    [SerializeField] private List<GameObject> itemObjs;
    private bool picking = false;
    private CurrentQuests currentQuests;
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerMove = transform.GetComponentInParent<PlayerMove>();
        direction = transform.right;
        foreach(Transform transform in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {
            if(transform.name=="InteractText")
            {
                InteractText = transform.GetComponent<Text>();
            }
            
            else if (transform.tag == "DialoguePanel")
            {

                DialoguePanel = transform.gameObject;
                currentDialogue = transform.GetComponent<CurrentDialogue>();
                
            }
        }
        foreach (Transform transform in GameObject.FindGameObjectWithTag("DontDestroyCanvas").GetComponentsInChildren<Transform>())
        {
             if (transform.tag == "InventoryPanel")
            {
                inventory = transform.GetComponent<Inventory>();
            }
        }

        currentQuests = GameObject.FindGameObjectWithTag("GameData").GetComponent<CurrentQuests>();

        InteractText.gameObject.SetActive(false);
        DialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement = PlayerMove.OutputMovement();


        if (Movement.y > 0)
        {
            direction = transform.up;
        }
        else if (Movement.y < 0)
        {
            direction = -transform.up;
        }

        if (Movement.x>0)
        {
            direction = transform.right;
        }
        else if(Movement.x<0)
        {
            direction = -transform.right;
        }


         Hit2D = Physics2D.Raycast(transform.position, direction,1f, rayMask);
        
        Debug.DrawRay(transform.position, direction,Color.black);
        
            
            if (Hit2D.collider != null&&Hit2D.transform.tag == "Box")
            {
                InteractText.gameObject.SetActive(true);
                InteractText.text = "Open box";

            }
            else if(itemObjs.Count!=0)
            {
                InteractText.gameObject.SetActive(true);
            InteractText.text = "Pick Up" + " " + itemObjs[0].GetComponent<GetItemData>().GetItemObj().name;

            
                if (Input.GetKeyDown(KeyCode.E))
                {
                    picking = true;
                    inventory.PickUpObject(itemObjs[0].GetComponent<GetItemData>().GetItemObj());
                    Destroy(itemObjs[0]);
                    itemObjs.Remove(itemObjs[0]);
                }
            }
            
            else if(Hit2D.collider != null&&Hit2D.transform.tag=="NPC")
            {
                InteractText.gameObject.SetActive(true);
                InteractText.text = "Talk";
                if(Input.GetKeyDown(KeyCode.E))
                {
                NpcTransform = Hit2D.transform;

                StartCalculating = true;
                    DialoguePanel.SetActive(true);
                foreach(QuestEventBase questEvent in currentQuests.GetEvents())
                {
                    if(questEvent.eventType==EventType.Dialogue)
                    {
                        DialogueEvent dialogueEvent = (DialogueEvent)questEvent;
                        if(dialogueEvent.Name== NpcTransform.GetComponent<NpcDialogue>().dialogue.Name&&!dialogueEvent.AddDialogues)
                        {
                            foreach(Dialogue dialogue in dialogueEvent.dialogue)
                            {
                                NpcTransform.GetComponent<NpcDialogue>().dialogue.dialogues.Add(dialogue);
                            }
                            dialogueEvent.AddDialogues = true;
                            
                        }
                    }
                        
                }
                    currentDialogue.Current = NpcTransform.GetComponent<NpcDialogue>().dialogue;
                    currentDialogue.StartDialogue();
                }

            }


        else
        {
            InteractText.gameObject.SetActive(false);
        }


        if(StartCalculating)
        {
            
            if(CalculateDistance(transform, NpcTransform)>2f)
            {

                QuitPanel();
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag=="Item")
        {
           
            itemObjs.Add(collision.gameObject);
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Item")
        {
            if(!picking)
            {
                itemObjs.Remove(collision.gameObject);
            }
            
            picking = false;
            
            
            
        }
    }

    private float CalculateDistance(Transform start,Transform end)
    {
        return Vector2.Distance(start.position, end.position);
    }


    public void QuitPanel()
    {
        StartCalculating = false;
        currentDialogue.CleanDialoguePanel();
        DialoguePanel.SetActive(false);
    }


    

}
