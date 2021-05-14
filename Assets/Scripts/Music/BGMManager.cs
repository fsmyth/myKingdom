using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    #pragma warning disable 649
     [SerializeField]
     private AudioClip castleMusic;
     [SerializeField]
     private AudioClip outsideMusic;
     [SerializeField]
     private AudioClip menuMusic;
     [SerializeField]
     private AudioSource source;
    #pragma warning restore 649

     public static BGMManager bGMManager;
     public string nowPlaying;
     //Starts the music when it's loaded.
     void Awake(){
         if (bGMManager == null){
             bGMManager = this;
             DontDestroyOnLoad(gameObject);
        } else if(bGMManager != this) {
             Destroy(gameObject);
     }
    }
    //Starts with the menu music.
    void Start() {
        MenuMusic();
    }

    //If in the castle, play the castle music.
    public static void CastleMusic() {
        if (bGMManager != null && bGMManager.nowPlaying !="Castle") {
            bGMManager.source.Stop();
            bGMManager.source.clip = bGMManager.castleMusic;
            bGMManager.source.Play();
            bGMManager.nowPlaying = "Castle";
        }
    }

    //If outside, play the outside music.
    public static void OutsideMusic() {
        if (bGMManager != null && bGMManager.nowPlaying !="Outside") {
            bGMManager.source.Stop();
            bGMManager.source.clip = bGMManager.outsideMusic;
            bGMManager.source.Play();
            bGMManager.nowPlaying = "Outside";
        }
    }

    //If in the menu, play the menu music.
    public static void MenuMusic() {
        if (bGMManager != null && bGMManager.nowPlaying !="Menu") {
            bGMManager.source.Stop();
            bGMManager.source.clip = bGMManager.menuMusic;
            bGMManager.source.Play();
            bGMManager.nowPlaying = "Menu";
        }
    }

    //If the player presses M, mutes the music.
    void Update() {
        if (Input.GetKeyDown(KeyCode.M)){
            if (bGMManager.source.mute) {
                bGMManager.source.mute = false;
            } else bGMManager.source.mute = true;
    }
    }
}
