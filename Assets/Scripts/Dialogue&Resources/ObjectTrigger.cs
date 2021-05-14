using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    //Initialises the dialogue variable.
    public Dialogue dialogue;
    //Initialises the player variable.
    public Transform player;
    //Sets the range for the player to be able to interact with the NPCs.
    public float range = 1.5f;

    void Update() 
    {
        //If the player's distance to the target is less than the range:
        if(Vector3.Distance(transform.position, player.position) < range){
            //If the player presses E:
            if (Input.GetKeyDown(KeyCode.E))
                {
                    //Activates the function TriggerDialogue().
                    TriggerDialogue();
                }
        }
    }

    public void TriggerDialogue () {
        //Finds the dialogue manager and runs the StartDialogue() function.
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
