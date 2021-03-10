using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator anim;

    Vector2 movement;
    public VectorValue startingPosition;
    //public Animator anim; //00w1a2s3d4
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero) {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
        anim.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement * moveSpeed * Time.fixedDeltaTime);
    }
}

