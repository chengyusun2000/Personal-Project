using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private Animator EnemyAnimator;
    private BoxCollider2D AttackBox;
    private PlayerInfo playerInfo;
    public bool OnlyOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimator = transform.GetComponentInParent<Animator>();
        playerInfo = GameObject.FindGameObjectWithTag("GameData").GetComponent<PlayerInfo>();
        AttackBox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerDamageCollision" && EnemyAnimator.GetBool("Attack") && !OnlyOnce)
        {
            playerInfo.AddHp(-10);
            OnlyOnce = true;
        }
    }
}
