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

    public void OnTriggerEnter2D(Collider2D other) 
    {
            if(other.CompareTag("Player") && !other.isTrigger) 
        {
            NPCManager.ResetDone();
            // NPCManager.PassDay();
            StartCoroutine(NextDay());
        }
        
    }

    IEnumerator NextDay() {
        playerMemory.initialValue = playerPosition;
        transition.SetTrigger("Next");
        yield return new WaitForSeconds(transitionTime);
        NPCManager.PassDay();
        SceneManager.LoadScene("Castle");
    }
}
