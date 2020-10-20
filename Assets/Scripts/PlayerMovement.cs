using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
        rb.velocity = new Vector2(0, moveSpeed);
    } else if(Input.GetKey(KeyCode.A)) {
        rb.velocity = new Vector2(-moveSpeed, 0);
    }  else if(Input.GetKey(KeyCode.S)) {
        rb.velocity = new Vector2(0, -moveSpeed);
    } else if(Input.GetKey(KeyCode.D)) {
        rb.velocity = new Vector2(moveSpeed, 0);
    } else rb.velocity = new Vector2(0,0);
    }
}

