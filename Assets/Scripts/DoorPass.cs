﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPass : MonoBehaviour
{
        public bool entry = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("Locked!");
            entry = true;
    }

    
    private void OnTriggerExit2D(Collider2D other) {
            entry = false;
    }
}
