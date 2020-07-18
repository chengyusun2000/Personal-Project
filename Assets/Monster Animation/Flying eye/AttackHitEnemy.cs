using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitEnemy : MonoBehaviour
{
    public Animator playeranimator;
    private Animator EnemyAnimator;
    public bool OnlyOnce = false;
    private TestEnemyHP testEnemyHP;
    private float MaxTime = 0.8f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        playeranimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        EnemyAnimator = transform.GetComponent<Animator>();
        testEnemyHP = transform.GetComponent<TestEnemyHP>();
    }

    // Update is called once per frame
    void Update()
    {
        SetOnlyOnce();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        testattack(collision.transform);
    }
    public void testattack(Transform AttackCollision)
    {

        if (AttackCollision != null)
        {
            if (playeranimator.GetBool("Attack") && !OnlyOnce && AttackCollision.tag == "AttackCollision")
            {
                Debug.Log("att");
                OnlyOnce = true;
                EnemyAnimator.SetBool("OnHit", true);
                
                
                

            }
        }

    }
    public void SetOnlyOnce()
    {
        if (OnlyOnce)
        {
            time = time + Time.deltaTime;
            if (time >= MaxTime)
            {
                OnlyOnce = false;
                time = 0f;
            }
        }
    }
}
