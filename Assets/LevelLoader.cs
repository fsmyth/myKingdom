using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    GameObject gate;
    DoorPass doorPass;
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gate = GameObject.Find("Gate");
        doorPass = gate.GetComponent<DoorPass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorPass.entry == true) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
