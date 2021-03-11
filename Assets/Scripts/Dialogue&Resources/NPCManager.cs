using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    public static bool minerDone;
    public static bool farmerDone;
    public static bool lumberDone;

     public static NPCManager nPCManager;
     
     void Awake()
     {
         if (nPCManager == null){
             nPCManager = this;
             DontDestroyOnLoad(gameObject);
        } else if(nPCManager != this) {
             Destroy(gameObject);
     }
    }

    public static void ResetDone() {
        minerDone = false;
        farmerDone = false;
        lumberDone = false;
    }

}
