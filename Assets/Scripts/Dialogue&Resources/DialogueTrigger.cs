using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Transform player;
    public Sprite lookUp;
    public Sprite lookDown;
    public Sprite lookL;
    public Sprite lookR;
    public SpriteRenderer sr;
    public float range = 1.5f;
    public bool collected;
    public int role;
    public int friendship;
    public int wood;
    public int food;
    public int iron;
    public int gold;

    void Update() 
    {
        //If the player is within the range to talk to the NPC:
        if(Vector3.Distance(transform.position, player.position) < range){
            //If the player presses E:
            if (Input.GetKeyDown(KeyCode.E))
                {
                    //Check if the NPC has already been talked to:
                    CheckCollected();
                    //If they haven't:
                    if(!collected) {
                    //Look at the player:
                    LookAtMe();
                    //Trigger dialogue.
                    TriggerDialogue();
                    //Set the variable to
                    SetCollected();
                    //Otherwise:
                    } else {
                    //Look at the player.
                    LookAtMe();
                    //Trigger alternate dialogue.
                    TriggerDialogue2();

                    }
                }
        }
        
                    wood = ResourceManager.GetWood();
                    food = ResourceManager.GetFood();
                    gold = ResourceManager.GetGold();
                    iron = ResourceManager.GetIron();
    
    }

    //The LookAtMe() function makes the NPC face the direction that the player is talking to them from.
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

    //Dialogue trigger 1:
    //This is triggered when the user hasn't spoken to the NPC before that day.
    public void TriggerDialogue () {
        //Finds the DialogueManager and then starts the StartDialogue() function.
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //The switch switches between cases for when the player is talking to different NPCs.
        switch (role) {
            default: break;
            case 1: 
                //Adds 5 iron.
                ResourceManager.AddIron(5);
                break;
            case 2: 
                //Adds 5 gold.
                ResourceManager.AddGold(5);
                break;
            case 3: 
                //Adds 5 wood.
                ResourceManager.AddWood(5);
                break;
            case 4: 
                //Adds 5 food.
                ResourceManager.AddFood(5);
                break;
            case 5: 
                //Adds 5 gold in exchange for 5 of each other resource.
                if(wood>=5 && food>=5 && iron>=5) {
                    ResourceManager.AddGold(5);
                    ResourceManager.SubFood(5);
                    ResourceManager.SubIron(5);
                    ResourceManager.SubWood(5);
                }
                
                break;
            
        }
        //Increases the friendship counter by 1.
        friendship++;
    }

    public void TriggerDialogue2 () {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);

    }

    //The CheckCollected() function calls the NPC manager to check if the resources have been collected that day.
    public void CheckCollected() {
        switch (role) {
            default: break;
            case 1: 
                collected = NPCManager.minerDone;
                break;
            case 3: 
                collected = NPCManager.lumberDone;
                break;
            case 4: 
                collected = NPCManager.farmerDone;
                break;
            case 5: 
                collected = NPCManager.bankerDone;
                break;
            
        }
    }

    //When the NPCs are talked to for the first time that day, their booleans are set to true.
    //This means that the player cannot get resources more than once per day.
    public void SetCollected() {
        switch (role) {
            default: break;
            case 1: 
                NPCManager.minerDone = true;
                break;
            case 3: 
                NPCManager.lumberDone = true;
                break;
            case 4: 
                NPCManager.farmerDone = true;
                break;
            case 5: 
                NPCManager.bankerDone = true;
                break;
            
        }
    }

}
