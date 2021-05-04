using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class PauseManager : MonoBehaviour
{
    public static TimeManager.TimeState store;      //¡‚ÌŠÔó‘Ô‚ğ•Û‚µ‚Ä‚¨‚­•Ï”

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public static void TimeStop()
    {
        Timekeeper.instance.Clock("Pause").localTimeScale = 0.0f;
        store = TimeManager.state;
        //TimeManager.state = TimeManager.TimeState.TIME_POSE;
    }

    public static void TimeStart()
    {
        Timekeeper.instance.Clock("Pause").localTimeScale = 1.0f;
        TimeManager.state = store;
    }
}
