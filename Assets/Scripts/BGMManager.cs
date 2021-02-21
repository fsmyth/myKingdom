using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
     [SerializeField]
     private AudioClip castleMusic;
     [SerializeField]
     private AudioClip outsideMusic;
     [SerializeField]
     private AudioSource source;


     public static BGMManager instance;
     
     void Awake(){
         if (instance!=null){
             GameObject.Destroy(instance);
     } else {
         instance = this;         
         DontDestroyOnLoad(this);
     }
    }

    void Start() {
        CastleMusic();
    }

    public static void CastleMusic() {
        if (instance != null) {
            instance.source.Stop();
            instance.source.clip = instance.castleMusic;
            instance.source.Play();
        }
    }

    public static void OutsideMusic() {
        if (instance != null) {
            instance.source.Stop();
            instance.source.clip = instance.outsideMusic;
            instance.source.Play();
        }
    }
}
