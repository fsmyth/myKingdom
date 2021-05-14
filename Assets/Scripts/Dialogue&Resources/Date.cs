using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    public Text d01, d10, m01, m10;   
    void Start()
    {
        
    }

    //Takes the dates from the NPC Manager and displays them.
    void Update()
    {
        d01.text = ""+NPCManager.GetDay();
        d10.text = ""+NPCManager.GetTenDay();
        m01.text = ""+NPCManager.GetMonth();
        m10.text = ""+NPCManager.GetTenMonth();
    }
}
