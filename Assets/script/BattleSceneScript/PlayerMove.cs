using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField]private Vector2 Movement;
    private Rigidbody2D PlayerRigi;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
       if(Input.GetButtonDown("Jump"))
        {
            PlayerRigi.AddForce(Movement);
        }
       
        
    }
    private void FixedUpdate()
    {
        PlayerRigi.MovePosition(Movement * speed + PlayerRigi.position);


   
    }
    public Vector2 OutputMovement()
    {
        return Movement;
    }
}
