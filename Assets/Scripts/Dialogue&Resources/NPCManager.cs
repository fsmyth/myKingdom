using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    //Sets booleans to store whether or not the player has interacted with the NPCs that dispense resources.
    public static bool minerDone;
    public static bool farmerDone;
    public static bool lumberDone;
    public static bool bankerDone;

    
    [SerializeField]
    //daysPassed stores the total number of days passed.
    //day stores the current day from 1-9.
    //tenday stores the count of each ten days.
    //month stores the current month from 1-9.
    //tenmoth stores the count of each ten months.
    private int daysPassed, day, tenday, month=1, tenmonth;

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

    void Update() {
    }

    //Resets the booleans to indicate that the player has collected the resources.
    //This function is called in NewDay.
    public static void ResetDone() {
        minerDone = false;
        farmerDone = false;
        lumberDone = false;
        bankerDone = false;
    }

    //The PassDay() function handles changing the date when the day is passed.
    public static void PassDay(){
        nPCManager.tenday = 0;
        nPCManager.month = 1;
        nPCManager.tenmonth = 0;
        nPCManager.daysPassed++;
        nPCManager.day = nPCManager.daysPassed;
        //When the days exceed 30, adds months.
        while(nPCManager.day>30) {
            nPCManager.day = nPCManager.day-30;
            if(nPCManager.month<9) {
                nPCManager.month++;
            } else {
                nPCManager.month = 0;
                nPCManager.tenmonth++;
            }
        }
        while (nPCManager.day>9) {
            nPCManager.day = nPCManager.day-10;
            nPCManager.tenday++;
        }
        if(nPCManager.tenmonth>=1){
            if(nPCManager.month>=2) {
            nPCManager.month = 0;
            nPCManager.tenmonth = 0;
            }
        }
    }

    public static int GetDay() {
        return nPCManager.day;
    }
    public static int GetTenDay() {
        return nPCManager.tenday;
    }    
    public static int GetMonth() {
        return nPCManager.month;
    }    
    public static int GetTenMonth() {
        return nPCManager.tenmonth;
    }

}
