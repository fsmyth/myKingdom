using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
//Text objects to display resources on HUD
    public Text ironDisplay;
    public Text goldDisplay;
    public Text woodDisplay;
    public Text foodDisplay;

//Ints to track resources
    int ironCount = 0;
    int goldCount = 0;
    int woodCount = 0;
    int foodCount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ironCount = ResourceManager.GetIron();
        goldCount = ResourceManager.GetGold();
        woodCount = ResourceManager.GetWood();
        foodCount = ResourceManager.GetFood();

        ironDisplay.text = "" + ironCount;
        goldDisplay.text = "" + goldCount;
        woodDisplay.text = "" + woodCount;
        foodDisplay.text = "" + foodCount;

    }
}
