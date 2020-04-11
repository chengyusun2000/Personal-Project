using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextTurn : MonoBehaviour
{
    public playerMovement playerMovement;
    public Button NextTurnButton;
    public bool EnemyTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        NextTurnButton = transform.GetComponentInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PressNextTurnButton()
    {
        EnemyTurn = true;

        playerMovement.StepCount = 0;
        
    }
}
