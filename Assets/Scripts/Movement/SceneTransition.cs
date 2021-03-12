using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public Transform player;
    public float range = 2f;
    public VectorValue playerMemory;
    public Animator transition;
    public float transitionTime = 2f;
    

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }
        
        if(gameObject.tag == "Map") {
            if(Vector3.Distance(transform.position, player.position) < range){
                if (Input.GetKeyDown(KeyCode.E))
                    {
                        StartCoroutine(LoadNext(sceneToLoad));
                    }
            }
        }
        

    }

    //If it's a door (i.e, tagged with portal), this function will be used
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (gameObject.tag == "Portal") {
            if(other.CompareTag("Player") && !other.isTrigger) 
        {
            StartCoroutine(LoadNext(sceneToLoad));
        }
        }
    }

    //If it's a button (i.e, tagged with Clickable), this function will be used.
    public void OnMouseDown() 
    {
        if(gameObject.tag == "Clickable") 
        {
            StartCoroutine(LoadNext(sceneToLoad));
        }
    }

    IEnumerator LoadNext(string sceneToLoad) {
        playerMemory.initialValue = playerPosition;
        transition.SetTrigger("Next");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneToLoad);
    }
}
