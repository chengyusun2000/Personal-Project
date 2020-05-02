using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interaction : MonoBehaviour
{
    public LayerMask rayMask;
   
    private PlayerMove PlayerMove;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Vector2 Movement;
    [SerializeField] private Text InteractText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = transform.GetComponent<PlayerMove>();
        direction = transform.right;
        foreach(Transform transform in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {
            if(transform.name=="InteractText")
            {
                InteractText = transform.GetComponent<Text>();
            }
        }
        InteractText.gameObject.SetActive(false);
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


        RaycastHit2D Hit2D = Physics2D.Raycast(transform.position, direction,1f, rayMask);
        Debug.DrawRay(transform.position, direction,Color.black);
        if(Hit2D.collider != null)
        {
            if (Hit2D.transform.tag == "Box")
            {
                InteractText.gameObject.SetActive(true);
                InteractText.text = "Open box";

            }
            
        }
        else
        {
            InteractText.gameObject.SetActive(false);
        }

    }
}
