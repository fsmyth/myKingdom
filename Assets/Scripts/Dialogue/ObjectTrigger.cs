using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform player;
    public float range = 1.5f;

    void Update() 
    {
        if(Vector3.Distance(transform.position, player.position) < range){
            if (Input.GetKeyDown(KeyCode.E))
                {
                    TriggerDialogue();
                }
        }
    }

    public void TriggerDialogue () {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
