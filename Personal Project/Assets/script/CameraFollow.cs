using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera camera;
    public Vector3 velocity;
    public Transform player;
    public float smoothTime;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
         

    }
    private void FixedUpdate()
    {
        x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity.x, smoothTime);
        y = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smoothTime);
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
