﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerMove : MonoBehaviour
{
    private float speed = 0.3f;
    [SerializeField]private Vector2 Movement;
    private Rigidbody2D PlayerRigi;
    private Animator PlayerAnimator;
    [SerializeField]private FaceMouse faceMouse;
    Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigi = this.GetComponent<Rigidbody2D>();
        PlayerAnimator = transform.GetComponent<Animator>();
        vector = transform.localScale;
        faceMouse = transform.Find("AttackCollision").GetComponent<FaceMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement.x = Input.GetAxis("Horizontal");
        //Movement.y = Input.GetAxis("Vertical");

        SetWalkingDirection();

        if (Input.GetButtonDown("Jump"))
        {
            PlayerRigi.AddForce(Movement);
        }

       


       
       if(Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Facing();
                PlayerAnimator.SetBool("StartAttack", true);
            }
               
            //StartCoroutine(Wait());
        }

        
    }


    private void FixedUpdate()
    {
        if(!PlayerAnimator.GetBool("StartAttack") && !PlayerAnimator.GetBool("Attack"))
        {
            speed = 0.1f;
            PlayerRigi.MovePosition(Movement * speed + PlayerRigi.position);
        }
        else if(!PlayerAnimator.GetBool("StartAttack")&& PlayerAnimator.GetBool("Attack"))
        {
            speed = 0.05f;
            PlayerRigi.MovePosition(Movement * speed + PlayerRigi.position);
        }
        


   
    }



    public Vector2 OutputMovement()
    {
        return Movement;
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerAnimator.SetBool("Attack", false);
    }


    public void Facing()
    {
        
        if(faceMouse.transform.eulerAngles.z>0&& faceMouse.transform.eulerAngles.z < 180)
        {
            transform.localScale = new Vector3(vector.x * -1, vector.y, vector.z);
        }
        else if (faceMouse.transform.eulerAngles.z >= 180 && faceMouse.transform.eulerAngles.z <=360)
        {
            transform.localScale = vector;
            
        }
    }


    public void SetWalkingDirection()
    {
        PlayerAnimator.SetFloat("UpOrDown", Movement.y);
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.A))
            {
                Movement.x = -1;
            }
            else
            {
                Movement.x = 1;
            }
            PlayerAnimator.SetBool("WalkLeftOrRight", true);
            
        }
        //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        else
        {
            Movement.x = 0;
            PlayerAnimator.SetBool("WalkLeftOrRight", false);
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if(Input.GetKey(KeyCode.W))
            {
                Movement.y = 1;
            }
            else
            {
                Movement.y = -1;
            }
        }
        //else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        else
        {
            Movement.y = 0;
        }




            if (Movement.x > 0)
        {
            PlayerAnimator.SetBool("Walk", true);
            if (!PlayerAnimator.GetBool("StartAttack") && !PlayerAnimator.GetBool("Attack"))
            {
                transform.localScale = vector;
            }


        }
        else if (Movement.x < 0)
        {
            PlayerAnimator.SetBool("Walk", true);
            if (!PlayerAnimator.GetBool("StartAttack") && !PlayerAnimator.GetBool("Attack"))
            {
                transform.localScale = new Vector3(vector.x * -1, vector.y, vector.z);
            }


        }
        else if(Movement.y!=0)
        {
            PlayerAnimator.SetBool("Walk", true);
        }
        else
        {
            PlayerAnimator.SetBool("Walk", false);
            Facing();
        }
    }
    
}
