using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public Text nameText;
    public Text dialogueText;

    public Animator anim;
    public Image portrait;

    private Queue<string> sentences;
    public GameObject player;
    public PlayerMovement pm;
    bool dialogueRunning = false;

    void Start()
    {
        //Place the sentences written in the editor into a Queue variable.
        sentences = new Queue<string>();
        //Find the player object
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }
    }

    void Update() {
        //While the player is talking to an NPC, set moveSpeed to 0 so the player can't move.
        if(dialogueRunning) {
            pm.moveSpeed = 0f;
        //When they're done, reset it to 5.
        } else pm.moveSpeed = 5f;
        //If the player is in a conversation, pressing space continues the conversation.
        if(dialogueRunning && Input.GetKeyDown("space")) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue) {
        //Make the dialogue box appear on-screen by playing the "isOpen" animation.
        anim.SetBool("isOpen", true);
        //Only start a conversation if there isn't one already running.
        if(!dialogueRunning){
            //Put the information from the object into the dialogue box.
            nameText.text = dialogue.name;
            portrait.sprite = dialogue.portrait;
            //Clear any previous text
            sentences.Clear();

            //Queue up the sentences to be displayed by the dialogue box
            foreach (string sentence in dialogue.sentences)
                {
                    sentences.Enqueue(sentence);
                }
            //Display the first sentence
            DisplayNextSentence();
            //This bool allows the script to keep track of whether a conversation is currently happening.
            dialogueRunning = true;
            }
    }

    public void DisplayNextSentence() {
        //If there are no more sentences, close the dialogue.
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }
        //Retrieve the next sentence from the queue
        string sentence = sentences.Dequeue();
        //Stop the game from trying to type the previous sentence if the user moves on too fast
        StopAllCoroutines(); 
        //Type out the sentence one character at a time instead of the text all appearing at once
        StartCoroutine(TypeDialogue(sentence));
        }

        IEnumerator TypeDialogue (string sentence) {
            //Set the displayed sentence to nothing
            dialogueText.text = "";
            //For every letter, add them to the sentence one by one, waiting one frame between each letter.
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }

    void EndDialogue() {
        //When the conversation is over, tell the script the dialogue is no longer running
        dialogueRunning = false;
        //Close the dialogue box with the animator
        anim.SetBool("isOpen", false);

    }
}
