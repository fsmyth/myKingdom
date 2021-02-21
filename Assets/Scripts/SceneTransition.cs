using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerMemory;
    public Animator transition;
    public float transitionTime = 1f;
    

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }

    }
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (gameObject.tag == "Portal") {
            if(other.CompareTag("Player") && !other.isTrigger) 
        {
            StartCoroutine(LoadNext(sceneToLoad));
            // playerMemory.initialValue = playerPosition;
            // SceneManager.LoadScene(sceneToLoad);
        }
        }
    }

    public void OnMouseDown() 
    {
        Debug.Log("Clicked!");
        if(gameObject.tag == "Clickable") 
        {
            StartCoroutine(LoadNext(sceneToLoad));
            // playerMemory.initialValue = playerPosition;
            // SceneManager.LoadScene(sceneToLoad);
        }
    }

    IEnumerator LoadNext(string sceneToLoad) {
        playerMemory.initialValue = playerPosition;
        transition.SetTrigger("Next");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneToLoad);
    }
}
