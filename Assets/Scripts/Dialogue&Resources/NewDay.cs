using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDay : MonoBehaviour
{

    public Vector2 playerPosition;
    public VectorValue playerMemory;
    public Animator transition;
    public float transitionTime = 1f;

    //If somehting enters the throne collider:
    public void OnTriggerEnter2D(Collider2D other) 
    {
            //If the object is the player:
            if(other.CompareTag("Player") && !other.isTrigger) 
        {
            //Calls the ResetDone fucntion.
            //This function resets the booleans that store if the player has collected resources.
            NPCManager.ResetDone();
            //Starts the NextDay coroutine which will advance the day.
            StartCoroutine(NextDay());
        }
        
    }

    //Sets the next scene, waits, and then loads the castle scene again.
    IEnumerator NextDay() {
        playerMemory.initialValue = playerPosition;
        transition.SetTrigger("Next");
        yield return new WaitForSeconds(transitionTime);
        NPCManager.PassDay();
        SceneManager.LoadScene("Castle");
    }
}
