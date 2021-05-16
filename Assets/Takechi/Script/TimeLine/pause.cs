using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Timekeeper.instance.Clock("Player").localTimeScale = 0.0f;
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Timekeeper.instance.Clock("Player").localTimeScale = 1.0f;
        }
    }
}
