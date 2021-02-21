using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuit : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger) 
        {
            StartCoroutine(ExitGame());
        }
    }

     public void QuitGame()
 {
     #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
 }

    IEnumerator ExitGame() {
        transition.SetTrigger("Next");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("Quit!");
        QuitGame();
    }
}
