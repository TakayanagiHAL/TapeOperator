using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class PauseManager : MonoBehaviour
{
    public static TimeManager.TimeState store;      //今の時間状態を保持しておく変数

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
        TimeManager.state = TimeManager.TimeState.TIME_PAUSE;
    }

    public static void TimeStart()
    {
        Timekeeper.instance.Clock("Pause").localTimeScale = 1.0f;
        TimeManager.state = store;
    }
}
