using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    public Animator playeranimator;
    public bool OnlyOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        playeranimator = transform.parent.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        FacingMouse();
    }


    public void FacingMouse()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;


        transform.up = direction;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        testattack(collision.transform);
    }


    public void testattack(Transform Enemy)
    {
        
        if(Enemy!=null)
        {
            if (playeranimator.GetBool("Attack") && !OnlyOnce&&Enemy.tag=="Enemy")
            {
                Debug.Log("att");
                TestEnemyHP testEnemyHP = Enemy.GetComponent<TestEnemyHP>();
                testEnemyHP.Hp--;
                OnlyOnce = true;
            }
        }
        
    }
}
