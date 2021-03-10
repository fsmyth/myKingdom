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
     
     void Awake(){
         if (bGMManager == null){
             bGMManager = this;
             DontDestroyOnLoad(gameObject);
        } else if(bGMManager != this) {
             Destroy(gameObject);
     }
    }

    void Start() {
        MenuMusic();
    }

    public static void CastleMusic() {
        if (bGMManager != null && bGMManager.nowPlaying !="Castle") {
            bGMManager.source.Stop();
            bGMManager.source.clip = bGMManager.castleMusic;
            bGMManager.source.Play();
            bGMManager.nowPlaying = "Castle";
        }
    }

    public static void OutsideMusic() {
        if (bGMManager != null && bGMManager.nowPlaying !="Outside") {
            bGMManager.source.Stop();
            bGMManager.source.clip = bGMManager.outsideMusic;
            bGMManager.source.Play();
            bGMManager.nowPlaying = "Outside";
        }
    }

    public static void MenuMusic() {
        if (bGMManager != null && bGMManager.nowPlaying !="Menu") {
            bGMManager.source.Stop();
            bGMManager.source.clip = bGMManager.menuMusic;
            bGMManager.source.Play();
            bGMManager.nowPlaying = "Menu";
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)){
            if (bGMManager.source.mute) {
                bGMManager.source.mute = false;
            } else bGMManager.source.mute = true;
    }
    }
}
