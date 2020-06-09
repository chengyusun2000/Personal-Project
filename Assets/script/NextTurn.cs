using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextTurn : MonoBehaviour
{
    public playerMovement playerMovement;
    public Button NextTurnButton;
    [SerializeField] private List<GameObject> EnemiesAndOthers;
    private EnemyTracking enemyTracking;
    [SerializeField]private bool EnemyStart = false;
    [SerializeField]private int Number = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        NextTurnButton = transform.GetComponentInChildren<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyStart)
        {
            
            enemyTracking = EnemiesAndOthers[Number].GetComponent<EnemyTracking>();
            if (Number<EnemiesAndOthers.Count && !enemyTracking.GetTurnFinished())
            {
               
                enemyTracking.SetEnemyTurn();
                
            }
            else if (Number < EnemiesAndOthers.Count && enemyTracking.GetTurnFinished())
            {
                enemyTracking.SetTurnFinished();
                Number++;
            }


            if (Number >= EnemiesAndOthers.Count)
            {
                EnemyStart = false;
                playerMovement.StepCount = 0;
                Number = 0;
            }
            

        }
    }


    public void PressNextTurnButton()
    {

        EnemyStart = true;
        
        
        
    }
}
