using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
     [SerializeField]
     private int iron;

     [SerializeField]
     private int gold;
    
     [SerializeField]
     private int wood;
    
     [SerializeField]
     private int food;


     public static ResourceManager resourceManager;
     
     void Awake() {
         if (resourceManager == null){
             resourceManager = this;
             DontDestroyOnLoad(gameObject);
        } else if(resourceManager != this) {
             Destroy(gameObject);
     }
    }


    public static int GetIron() {
        return resourceManager.iron;
    }
    public static int GetGold() {
        return resourceManager.gold;
    }
    public static int GetWood() {
        return resourceManager.wood;
    }
    public static int GetFood() {
        return resourceManager.food;
    }

    public static void AddIron(int ironAdded) {
        resourceManager.iron = resourceManager.iron+ironAdded;
    }

    public static void AddGold(int goldAdded) {
        resourceManager.gold = resourceManager.gold+goldAdded;
    }

    public static void AddWood(int woodAdded) {
        resourceManager.wood = resourceManager.wood+woodAdded;
    }

    public static void AddFood(int foodAdded) {
        resourceManager.food = resourceManager.food+foodAdded;
    }
}
