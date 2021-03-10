using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMWild : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        BGMManager.OutsideMusic();
    }
}
