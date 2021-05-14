using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Location : MonoBehaviour
{
    public Text locationName;

    void Start()
    {
        //Gets the name of the active scene to display on the HUD.
        locationName.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
