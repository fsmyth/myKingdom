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
        sentences = new Queue<string>();
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }
    }

    void Update() {
        if(dialogueRunning) {
            pm.moveSpeed = 0f;
        } else pm.moveSpeed = 5f;
        if(dialogueRunning && Input.GetKeyDown("space")) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue) {
        anim.SetBool("isOpen", true);
        if(!dialogueRunning){
        // Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        portrait.sprite = dialogue.portrait;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        dialogueRunning = true;
    }}

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //Stop the game from trying to type the previous sentence if the user moves on too fast
        StartCoroutine(TypeDialogue(sentence));
        }

        IEnumerator TypeDialogue (string sentence) {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }

    void EndDialogue() {
        // Debug.Log ("End of conversation");
        dialogueRunning = false;
        anim.SetBool("isOpen", false);

    }
}
