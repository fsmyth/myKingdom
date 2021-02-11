using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform player;
    public Sprite lookUp;
    public Sprite lookDown;
    public Sprite lookL;
    public Sprite lookR;
    public SpriteRenderer sr;
    public float range = 1.5f;

    void Update() 
    {
        if(Vector3.Distance(transform.position, player.position) < range){
            if (Input.GetKeyDown(KeyCode.E))
                {
                    LookAtMe();
                    TriggerDialogue();
                }
        }
    }

    public void LookAtMe() {
        if(player.position.x<transform.position.x) {
            sr.sprite = lookL;
        } else if (player.position.x>transform.position.x) {
            sr.sprite = lookR;
        }
        if(player.position.y<transform.position.y-0.5) {
            sr.sprite = lookDown;
        } else if (player.position.y>transform.position.y+0.5) {
            sr.sprite = lookUp;
        }
    }

    public void TriggerDialogue () {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
