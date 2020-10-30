using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerMemory;
    

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }

    }
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger) 
        {
            playerMemory.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
