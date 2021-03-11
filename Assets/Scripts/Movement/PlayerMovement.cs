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
    void Start()
    {
        //When a new scene is loaded, the player is placed into the appropriate location as directed by the previous scene.
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        //Reads the input from the horizontal movement keys (A,D, Left Arrow and Right Arrow) 
        //And applies their values to the Vector2 movement, allowing the player to move.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(moveSpeed > 0) { //When moveSpeed is zero, these animations will not play. This is to prevent the player from moving while in a conversation!
            if(movement != Vector2.zero) {
                //These will play the corresponding directional animations when the player moves.
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", movement.y);
            }
            //Tells the animator the speed at which player is moving. This is so the anim knows to play the walk animation.
            //Using sqrMagnitude instead of magnitude is much less processor-intensive.
            anim.SetFloat("Speed", movement.sqrMagnitude);
            }

    }

    void FixedUpdate()
    {
        //This takes the values taken in and calculated, then converts them into actual movement of the player object.
        rb.MovePosition(rb.position+movement * moveSpeed * Time.fixedDeltaTime);
    }
}

